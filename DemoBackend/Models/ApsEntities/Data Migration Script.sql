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
	IsMilitary, WorkGroup, ProcessTimeType, OpTimePerItem, BatchTime, Product, ProjectCode, KitNumber)
SELECT OrdersId, DatasetId, StartTime, EndTime, DueDate, OrderNo, OperationName, OpNo, Quantity, MidBatchQuantity, Resource, PartNo,
	IsMilitary, WorkGroup, ProcessTimeType, OpTimePerItem, BatchTime, Product, ProjectCode, KitNumber
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

declare @fact table (orderNo nvarchar(99), qty nvarchar(10), maxOpNo nvarchar(10), doneOpNo nvarchar(99));
insert into @fact values 
('1020_1707_253_11.0610.3.801.900', '4', '80', '28'),
('1020_1707_253_11.0610.3.802.900', '4', '80', '28'),
('1020_1707_258_11.0670.3.012.900', '4', '15', '5'),
('1020_1707_258_11.0670.3.016.900', '4', '15', '5'),
('1020_1707_271_11.0620.3.559.900', '2', '75', '26'),
('1020_1707_275_11.3170.I.002.900', '4', '95', '33'),
('1020_1707_275_11.3170.I.004.900', '4', '70', '24'),
('1020_1707_356_11.3510.I.810.001', '2', '10', '3'),
('1020_1707_356_11.3510.I.810.002', '2', '10', '3'),
('1020_1707_376_11.3320.I.202.900', '4', '100', '35'),
('1020_1707_377_11.3430.I.516.900', '2', '135', '47'),
('1020_1707_377_11.3430.I.616.900', '2', '140', '49'),
('1020_1707_377_11.3440.I.516.900', '2', '135', '47'),
('1020_1707_377_11.3440.I.536.900', '4', '105', '37'),
('1020_1707_377_11.3440.I.616.900', '2', '135', '47'),
('1020_1707_378_11.3460.I.501.900', '4', '100', '35'),
('1020_1707_378_11.3460.I.502.900', '4', '100', '35'),
('1020_1707_456_11.0247.3.101.900', '2', '115', '40'),
('1020_1707_456_11.0247.I.001.003', '2', '180', '63'),
('1020_1707_462_11.0212.I.016.900', '2', '125', '44'),
('1020_1707_462_11.0216.I.001.900', '2', '105', '37'),
('1020_1707_463_11.0201.1.801.900', '2', '190', '66'),
('1020_1707_463_11.0201.1.802.900', '2', '170', '59'),
('1020_1707_463_11.0235.I.021.900', '2', '115', '40'),
('1020_1707_465_11.0780.I.811.900', '2', '10', '3'),
('1020_1707_468_11.0240.4.801.900', '2', '170', '59'),
('1020_1707_469_11.0245.I.137.900', '2', '225', '79'),
('1020_1707_469_11.0245.I.138.900', '2', '130', '45'),
('1020_1707_469_11.0245.I.258.900', '2', '135', '47'),
('1020_1707_510_11.1005.7.059.001', '2', '15', '5'),
('1020_1707_510_11.1005.7.059.002', '2', '15', '5'),
('1020_1707_514_11.1102.3.106.900', '4', '140', '49'),
('1020_1707_518_11.1021.4.102.900', '2', '220', '77'),
('1020_1707_520_11.1002.3.803.005', '2', '160', '56'),
('1020_1707_521_11.1014.4.007.003', '2', '90', '31'),
('1020_1707_521_11.1014.4.903.003', '2', '85', '29'),
('1020_1707_521_11.1014.4.904.900', '2', '85', '29'),
('1020_1707_521_E10.1011.0801.003', '2', '85', '29'),
('1020_1707_521_E10.1011.0802.002', '2', '75', '26'),
('1020_1708_253_11.0610.3.801.900', '4', '80', '28'),
('1020_1708_253_11.0610.3.802.900', '4', '80', '28'),
('1020_1708_258_11.0670.3.012.900', '4', '15', '5'),
('1020_1708_258_11.0670.3.016.900', '4', '15', '5'),
('1020_1708_259_11.0670.3.814.900', '1', '105', '37'),
('1020_1708_259_11.0670.I.904.900', '1', '115', '40'),
('1020_1708_271_11.0620.3.559.900', '2', '75', '26'),
('1020_1708_275_11.3170.I.002.900', '4', '95', '33'),
('1020_1708_275_11.3170.I.004.900', '4', '70', '24'),
('1020_1708_275_11.3170.I.200.001', '2', '15', '5'),
('1020_1708_356_11.3510.I.810.001', '2', '10', '3'),
('1020_1708_356_11.3510.I.810.002', '2', '10', '3'),
('1020_1708_376_11.3320.I.202.900', '4', '100', '35'),
('1020_1708_377_11.3430.I.516.900', '2', '135', '47'),
('1020_1708_377_11.3430.I.616.900', '2', '140', '49'),
('1020_1708_377_11.3440.I.516.900', '2', '135', '47'),
('1020_1708_377_11.3440.I.536.900', '4', '105', '37'),
('1020_1708_377_11.3440.I.616.900', '2', '135', '47'),
('1020_1708_378_11.3460.I.501.900', '4', '100', '35'),
('1020_1708_378_11.3460.I.502.900', '4', '100', '35'),
('1020_1708_456_11.0247.3.101.900', '2', '115', '40'),
('1020_1708_456_11.0247.I.001.003', '2', '180', '63'),
('1020_1708_462_11.0212.I.016.900', '2', '125', '44'),
('1020_1708_462_11.0216.I.001.900', '2', '105', '37'),
('1020_1708_463_11.0201.1.801.900', '2', '190', '66'),
('1020_1708_463_11.0201.1.802.900', '2', '170', '59'),
('1020_1708_463_11.0235.I.021.900', '2', '115', '40'),
('1020_1708_465_11.0780.I.811.900', '2', '10', '3'),
('1020_1708_468_11.0240.4.801.900', '2', '170', '59'),
('1020_1708_469_11.0245.I.137.900', '2', '225', '79'),
('1020_1708_469_11.0245.I.138.900', '2', '130', '45'),
('1020_1708_469_11.0245.I.258.900', '2', '135', '47'),
('1020_1708_510_11.1005.7.059.001', '2', '15', '5'),
('1020_1708_510_11.1005.7.059.002', '2', '15', '5'),
('1020_1708_514_11.1102.3.106.900', '4', '140', '49'),
('1020_1708_518_11.1021.4.102.900', '2', '220', '77'),
('1020_1708_520_11.1002.3.803.005', '2', '160', '56'),
('1020_1708_521_11.1014.4.007.003', '2', '90', '31'),
('1020_1708_521_11.1014.4.903.003', '2', '85', '29'),
('1020_1708_521_11.1014.4.904.900', '2', '85', '29'),
('1020_1708_521_E10.1011.0801.003', '2', '85', '29'),
('1020_1708_521_E10.1011.0802.002', '2', '75', '26'),
('1022_1005_377_11.3430.I.516.900', '2', '135', '47'),
('1022_1005_377_11.3430.I.616.900', '2', '140', '49'),
('1022_1005_377_11.3440.I.516.900', '2', '135', '47'),
('1022_1005_377_11.3440.I.536.900', '4', '105', '37'),
('1022_1005_377_11.3440.I.616.900', '2', '135', '47'),
('1022_1005_378_11.3460.I.501.900', '4', '100', '35'),
('1022_1005_378_11.3460.I.502.900', '4', '100', '35'),
('1022_1005_462_11.0212.I.016.900', '2', '125', '44'),
('1022_1005_462_11.0216.I.001.900', '2', '105', '37'),
('1022_1005_518_11.1021.4.102.900', '2', '220', '77'),
('1022_1005_520_11.1002.3.803.005', '2', '160', '56'),
('1022_1006_377_11.3430.I.516.900', '2', '135', '47'),
('1022_1006_377_11.3430.I.616.900', '2', '140', '49'),
('1022_1006_377_11.3440.I.516.900', '2', '135', '47'),
('1022_1006_377_11.3440.I.536.900', '4', '105', '37'),
('1022_1006_377_11.3440.I.616.900', '2', '135', '47'),
('1022_1006_378_11.3460.I.501.900', '4', '100', '35'),
('1022_1006_378_11.3460.I.502.900', '4', '100', '35'),
('1022_1006_462_11.0212.I.016.900', '2', '125', '44'),
('1022_1006_462_11.0216.I.001.900', '2', '105', '37'),
('1022_1006_518_11.1021.4.102.900', '2', '220', '77'),
('1022_1006_520_11.1002.3.803.005', '2', '160', '56'),
('1023_1011_394_11.3115.3.001.900', '8', '160', '56'),
('1023_1011_394_11.3122.3.031.900', '8', '105', '37'),
('1023_1012_394_11.3115.3.001.900', '8', '160', '56'),
('1023_1012_394_11.3122.3.031.900', '8', '105', '37'),
('1023_1012_469_11.0245.I.137.900', '4', '225', '79'),
('1023_1012_469_11.0245.I.138.900', '4', '130', '45'),
('1023_1012_469_11.0245.I.258.900', '4', '135', '47'),
('1023_1013_394_11.3115.3.001.900', '8', '160', '56'),
('1023_1013_394_11.3122.3.031.900', '8', '105', '37'),
('1023_1013_469_11.0245.I.137.900', '4', '225', '79'),
('1023_1013_469_11.0245.I.138.900', '4', '130', '45'),
('1023_1013_469_11.0245.I.258.900', '4', '135', '47'),
('1023_1014_253_11.0610.3.801.900', '4', '80', '28'),
('1023_1014_253_11.0610.3.802.900', '4', '80', '28'),
('1023_1014_275_11.3170.I.002.900', '4', '95', '33'),
('1023_1014_275_11.3170.I.004.900', '4', '70', '24'),
('1023_1014_394_11.3115.3.001.900', '8', '160', '56'),
('1023_1014_394_11.3122.3.031.900', '8', '105', '37'),
('1023_1014_469_11.0245.I.137.900', '4', '225', '79'),
('1023_1014_469_11.0245.I.138.900', '4', '130', '45'),
('1023_1014_469_11.0245.I.258.900', '4', '135', '47'),
('1023_1014_518_11.1021.4.102.900', '2', '220', '77'),
('1023_1014_520_11.1002.3.803.005', '2', '160', '56'),
('1023_1014_521_11.1014.4.007.003', '2', '90', '31'),
('1023_1014_521_11.1014.4.903.003', '2', '85', '29'),
('1023_1014_521_11.1014.4.904.900', '2', '85', '29'),
('1023_1014_521_E10.1011.0801.003', '2', '85', '29'),
('1023_1014_521_E10.1011.0802.002', '2', '75', '26'),
('1023_1015_253_11.0610.3.801.900', '4', '80', '28'),
('M14041112', '1', '71', '25'),
('M14044246', '1', '47', '16'),
('M14063550', '1', '85', '29'),
('M14075388', '1', '57', '20'),
('M14084270', '1', '57', '20'),
('M14086195', '1', '54', '19'),
('M14088496', '1', '54', '19'),
('M14088497', '1', '54', '19'),
('M14103944', '1', '66', '23'),
('M14134557', '1', '58', '20'),
('M14134570', '1', '57', '20'),
('M14134613', '1', '46', '16'),
('M14134614', '1', '46', '16'),
('M14134675', '1', '48', '16'),
('M14134676', '1', '48', '16'),
('M14134687', '1', '83', '29'),
('M14134688', '1', '83', '29'),
('M14134689', '1', '83', '29'),
('M14134709', '1', '25', '8'),
('M14134710', '1', '25', '8');

select *, cast (doneOpNo as int) from @fact

update Orders set MidBatchQuantity = Quantity
from Orders ord
	join @fact f on ord.DatasetId = 46 and ord.OrderNo = f.orderNo and ord.OpNo <= cast(f.doneOpNo as int)