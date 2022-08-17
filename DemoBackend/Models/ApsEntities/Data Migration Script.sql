DELETE [OrderSecConstraints]
DELETE [OrderLinks]
DELETE [Orders]
DELETE [SecConstraintWorkgroup]
DELETE [SecConstraints]
DELETE [Workgroups]
DELETE [Resources]
DELETE [Orders_Dataset]

SET IDENTITY_INSERT [Orders_Dataset] ON
INSERT INTO [Orders_Dataset] (DatasetId, Name)
SELECT DatasetId, Name
FROM [IAZ Preactor Source].[UserData].[Orders_Dataset]
GO
SET IDENTITY_INSERT [Orders_Dataset] OFF

SET IDENTITY_INSERT [Resources] ON
INSERT INTO [Resources] (ResourceId, Name, FiniteOrInfinite, ResourceGroup)
SELECT res.ResourcesId, res.Name, res.FiniteOrInfinite, min(rg.Name)
FROM [IAZ Preactor Source].[UserData].[Resources] res
	join [IAZ Preactor Source].UserData.ResourceGroupsResources rgr on res.ResourcesId = rgr.Resources
	join [IAZ Preactor Source].UserData.ResourceGroups rg on rgr.ResourceGroupsId = rg.ResourceGroupsId
group by res.ResourcesId, res.Name, res.FiniteOrInfinite
GO
SET IDENTITY_INSERT [Resources] OFF

INSERT INTO Workgroups (Number, IsServiceGroup)
SELECT GroupNumber, ServiceGroup
FROM [IAZ Preactor Source].[UserData].[WorkGroups]
WHERE Workshop = 221
GO

SET IDENTITY_INSERT [SecConstraints] ON
INSERT INTO [SecConstraints] (SecConstraintId, Name, TypeName, ProfessionCode)
SELECT SecondaryConstraintsId, SecondaryConstraints.Name, SecondaryConstraintTypes.Name, ProfessionCode
FROM [IAZ Preactor Source].[UserData].[SecondaryConstraints]
	join [IAZ Preactor Source].[UserData].[SecondaryConstraintTypes] on SecondaryConstraints.SecondaryConstraintTypeName = SecondaryConstraintTypes.SecondaryConstraintTypesId
GO
SET IDENTITY_INSERT [SecConstraints] OFF

INSERT INTO SecConstraintWorkgroup([WorkersSecConstraintId], [WorkgroupsNumber])
SELECT wgw.Workers, wg.GroupNumber
FROM [IAZ Preactor Source].[UserData].[WorkGroupsWorkers] wgw
	JOIN [IAZ Preactor Source].[UserData].[WorkGroups] wg on wgw.WorkGroupsId = wg.WorkGroupsId and wg.Workshop = 221
GO

INSERT INTO [Orders] (OrderId, DatasetId, StartTime, EndTime, DueDate, OrderNo, OperationName, OpNo, Quantity, MidBatchQuantity, ResourceId, PartNo,
	IsMilitary, WorkGroup, ProcessTimeType, OpTimePerItem, BatchTime)
SELECT OrdersId, DatasetId, StartTime, EndTime, DueDate, OrderNo, OperationName, OpNo, Quantity, MidBatchQuantity, Resource, PartNo,
	IsMilitary, WorkGroup, ProcessTimeType, OpTimePerItem, BatchTime
FROM [IAZ Preactor Source].[UserData].[Orders]
WHERE OrderNo != '' and OperationName != '' and Quantity > 0 and ((Resource is null) or (Resource in (select ResourcesId from [IAZ Preactor Source].[UserData].[Resources])))
GO

INSERT INTO [OrderLinks] (DatasetId, FromOrderId, ToOrderId)
SELECT DatasetId, FromInternalSupplyOrder, ToInternalDemandOrder
FROM [IAZ Preactor Source].[UserData].[OrderLinks] ol
WHERE exists (select * from Orders ord where ord.DatasetId = ol.DatasetId and ord.OrderId = ol.FromInternalSupplyOrder) and
	exists (select * from Orders ord where ord.DatasetId = ol.DatasetId and ord.OrderId = ol.ToInternalDemandOrder)
GO

INSERT INTO [OrderSecConstraints] (DatasetId, OrderId, SecConstraintId, ConstraintUsage, ConstraintQuantity, StartTime, EndTime)
SELECT DatasetId, OrdersId, SecondaryConstraints, ConstraintUsage, ConstraintQuantity, cast('20000101' as datetime), cast('20000101' as datetime)
FROM [IAZ Preactor Source].[UserData].[OrdersSecondaryConstraints] osc
WHERE exists (select * from Orders ord where ord.DatasetId = osc.DatasetId and ord.OrderId = osc.OrdersId)
	and exists (select * from SecConstraints sc where sc.SecConstraintId = osc.SecondaryConstraints)
GO

INSERT INTO [OrderSecConstraints] (DatasetId, OrderId, SecConstraintId, ConstraintUsage, ConstraintQuantity, StartTime, EndTime)
SELECT wsao.DatasetId, ord.OrdersId, sc.SecondaryConstraintsId, 100, 1, wsao.OperationStart, wsao.OperationStart + wsao.OperationDuration OperationEnd
FROM [IAZ Preactor Source].UserData.WorkerShiftsAttachedOperations wsao
	join [IAZ Preactor Source].UserData.WorkerShifts ws on wsao.DatasetId = ws.DatasetId and wsao.WorkerShiftsId = ws.WorkerShiftsId
	join [IAZ Preactor Source].UserData.Workers wr on ws.Worker = wr.WorkersId
	join [IAZ Preactor Source].UserData.SecondaryConstraints sc on sc.Name like wr.WorkerCode + '%'
	join [IAZ Preactor Source].UserData.Orders ord on wsao.DatasetId = ord.DatasetId and wsao.AttachedOperations = ord.OrdersId
WHERE exists (select * from Orders where DatasetId = ord.DatasetId and OrderId = ord.OrdersId)
	and exists (select * from SecConstraints sc where sc.SecConstraintId = sc.SecConstraintId)
GO