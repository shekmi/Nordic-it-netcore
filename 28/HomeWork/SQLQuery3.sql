CREATE TABLE dbo.SendingStatus(
	Id INT NOT NULL,
	StatusName VARCHAR(50),
	CONSTRAINT PK_SendingStatus PRIMARY KEY CLUSTERED (Id))


CREATE TABLE dbo.�ontractors(
	PassportId INT NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	Position NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_PassportId PRIMARY KEY CLUSTERED (PassportId))


CREATE TABLE dbo.BranchOffice(
	BranchOfficeId INT NOT NULL,
	FullName NVARCHAR(20) NOT NULL,
	AddressOffice NVARCHAR(250) NOT NULL,
	CONSTRAINT PK_BranchOfficeId PRIMARY KEY CLUSTERED (BranchOfficeId))


CREATE TABLE dbo.Correspondence(
	CorrespondenceIdPC INT NOT NULL,
	NameDeparture VARCHAR(50) NOT NULL,
	NumberOfPage INT NOT NULL,
	CONSTRAINT CorrespondenceIdPC PRIMARY KEY CLUSTERED (CorrespondenceIdPC))


CREATE TABLE dbo.Sending(
	SendingId INT NOT NULL,
	SendingPassportId INT NOT NULL,
	SendingBranchOfficeId INT NOT NULL,
	RecipientPassportId INT NOT NULL,
	RecipientBranchOfficeId INT NOT NULL,
	SendingCorrespondenceIdPC INT NOT NULL,
	CONSTRAINT PK_Sending PRIMARY KEY CLUSTERED (SendingId),
	CONSTRAINT FK_Sending_SendingPassportId FOREIGN KEY (SendingPassportId)
		REFERENCES dbo.�ontractors(PassportId),
	CONSTRAINT FK_Sending_SendingBranchOfficeId FOREIGN KEY (SendingBranchOfficeId)
	REFERENCES dbo.BranchOffice(BranchOfficeId),
		CONSTRAINT FK_Sending_RecipientPassportId FOREIGN KEY (RecipientPassportId)
	REFERENCES dbo.�ontractors(PassportId),
		CONSTRAINT FK_Sending_RecipientBranchOfficeId FOREIGN KEY (RecipientBranchOfficeId)
	REFERENCES dbo.BranchOffice(BranchOfficeId),
	CONSTRAINT FK_Sending_SendingCorrespondenceIdPC FOREIGN KEY (SendingCorrespondenceIdPC)
		REFERENCES dbo.Correspondence(CorrespondenceIdPC))




CREATE TABLE dbo.SendingFlow(
	SendingId INT NOT NULL,
	SendingStatusId INT NOT NULL,
	ChangeDate DATETIMEOFFSET NOT NULL,
	CONSTRAINT PK_SendingFlow PRIMARY KEY CLUSTERED (SendingId, SendingStatusId, ChangeDate),
	CONSTRAINT FK_SendingFlow_SendingStatus FOREIGN KEY (SendingStatusId)
		REFERENCES dbo.SendingStatus(Id),
	CONSTRAINT FK_SendingFlow_SendingId FOREIGN KEY (SendingId)
		REFERENCES dbo.Correspondence(CorrespondenceIdPC))


INSERT INTO dbo.SendingStatus
	SELECT 1, '������� ��������'
INSERT INTO dbo.SendingStatus
	SELECT 2, '����������'
INSERT INTO dbo.SendingStatus
	SELECT 3, '�������'


SELECT * FROM dbo.SendingStatus


INSERT INTO dbo.�ontractors
	SELECT 1235677, '������� ����� ���������', '������������� �����'
INSERT INTO dbo.�ontractors
	SELECT 8881223, '������ ���� ��������', '���������'
INSERT INTO dbo.�ontractors
	SELECT 324234, '������ ���� ��������', '���������'


SELECT * FROM dbo.�ontractors


INSERT INTO dbo.BranchOffice
	SELECT 1, '������', '��. ������� �������, �. 10'
INSERT INTO dbo.BranchOffice
	SELECT 2, '�����-���������', '��. �������, �. 22'


SELECT * FROM dbo.BranchOffice


INSERT INTO dbo.Correspondence
	SELECT 1, '��������� �����', 364
INSERT INTO dbo.Correspondence
	SELECT 2, '��������� �� ���������', 7


SELECT * FROM dbo.Correspondence


INSERT INTO dbo.Sending
	SELECT 1, 1235677, 1, 8881223, 2, 1
INSERT INTO dbo.Sending
	SELECT 2, 8881223, 2, 1235677, 1, 2

SELECT * FROM dbo.Sending

INSERT INTO dbo.SendingFlow
	SELECT 1, 1, '25.05.2019 11:55:00'
INSERT INTO dbo.SendingFlow
	SELECT 1, 2, '25.05.2019 14:00:00'
INSERT INTO dbo.SendingFlow
	SELECT 1, 3, '26.05.2019 8:00:00'
INSERT INTO dbo.SendingFlow
	SELECT 2, 1, '28.05.2019 21:00:00'
INSERT INTO dbo.SendingFlow
	SELECT 2, 2, '29.05.2019 10:15:00'
INSERT INTO dbo.SendingFlow
	SELECT 2, 3, '30.05.2019 8:00:00'

SELECT * FROM dbo.SendingFlow
