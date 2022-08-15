DELETE [OrderSecConstraints]
DELETE [OrderLinks]
DELETE [Orders]
DELETE [SecConstraints]
DELETE [Resources]
DELETE [Orders_Dataset]

SET IDENTITY_INSERT [Orders_Dataset] ON
INSERT INTO [Orders_Dataset] (DatasetId, Name)
SELECT DatasetId, Name
FROM [IAZ Preactor Source].[UserData].[Orders_Dataset]
GO
SET IDENTITY_INSERT [Orders_Dataset] OFF

SET IDENTITY_INSERT [Resources] ON
INSERT INTO [Resources] (ResourceId, Name, FiniteOrInfinite)
SELECT ResourcesId, Name, FiniteOrInfinite
FROM [IAZ Preactor Source].[UserData].[Resources]
GO
SET IDENTITY_INSERT [Resources] OFF

SET IDENTITY_INSERT [SecConstraints] ON
INSERT INTO [SecConstraints] (SecConstraintId, Name, TypeName)
SELECT SecondaryConstraintsId, SecondaryConstraints.Name, SecondaryConstraintTypes.Name
FROM [IAZ Preactor Source].[UserData].[SecondaryConstraints]
	join [IAZ Preactor Source].[UserData].[SecondaryConstraintTypes] on SecondaryConstraints.SecondaryConstraintTypeName = SecondaryConstraintTypes.SecondaryConstraintTypesId
GO
SET IDENTITY_INSERT [SecConstraints] OFF

INSERT INTO [Orders] (OrderId, DatasetId, StartTime, EndTime, DueDate, OrderNo, OperationName, OpNo, Quantity, MidBatchQuantity, ResourceId, PartNo, IsMilitary, WorkGroup)
SELECT OrdersId, DatasetId, StartTime, EndTime, DueDate, OrderNo, OperationName, OpNo, Quantity, MidBatchQuantity, Resource, PartNo, IsMilitary, WorkGroup
FROM [IAZ Preactor Source].[UserData].[Orders]
WHERE OrderNo != '' and OperationName != '' and Quantity > 0 and ((Resource is null) or (Resource in (select ResourcesId from [IAZ Preactor Source].[UserData].[Resources])))
GO

INSERT INTO [OrderLinks] (DatasetId, FromOrderId, ToOrderId)
SELECT DatasetId, FromInternalSupplyOrder, ToInternalDemandOrder
FROM [IAZ Preactor Source].[UserData].[OrderLinks] ol
WHERE exists (select * from Orders ord where ord.DatasetId = ol.DatasetId and ord.OrderId = ol.FromInternalSupplyOrder) and
	exists (select * from Orders ord where ord.DatasetId = ol.DatasetId and ord.OrderId = ol.ToInternalDemandOrder)
GO

INSERT INTO [OrderSecConstraints] (DatasetId, OrderId, SecConstraintId, ConstraintUsage, ConstraintQuantity)
SELECT DatasetId, OrdersId, SecondaryConstraints, ConstraintUsage, ConstraintQuantity
FROM [IAZ Preactor Source].[UserData].[OrdersSecondaryConstraints] osc
WHERE exists (select * from Orders ord where ord.DatasetId = osc.DatasetId and ord.OrderId = osc.OrdersId)
	and exists (select * from [IAZ Preactor Source].UserData.SecondaryConstraints sc where sc.SecondaryConstraintsId = osc.SecondaryConstraints)
GO