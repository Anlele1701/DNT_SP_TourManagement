CREATE TABLE [dbo].[SPTOUR] (
    [ID_SPTour]    VARCHAR (10)    NOT NULL,
    [TenSPTour]    NVARCHAR (70)   NULL,
    [GiaNguoiLon]  INT             NULL,
    [NgayKhoiHanh] DATE            NULL,
    [NgayKetThuc]  DATE            NULL,
    [MoTa]         NVARCHAR (500)  NULL,
    [DiemTapTrung] NVARCHAR (50)   NULL,
    [DiemDen]      NVARCHAR (50)   NULL,
    [SoNguoi]      INT             NULL,
    [HinhAnh]      VARCHAR(MAX) NULL,
    [GiaTreEm]     INT             NULL,
    [ID_NV]        INT             NULL,
    [ID_TOUR]      CHAR (2)        NOT NULL,
    PRIMARY KEY CLUSTERED ([ID_SPTour] ASC),
    FOREIGN KEY ([ID_NV]) REFERENCES [dbo].[NHANVIEN] ([ID_NV]),
    FOREIGN KEY ([ID_TOUR]) REFERENCES [dbo].[TOUR] ([ID_TOUR])
);

