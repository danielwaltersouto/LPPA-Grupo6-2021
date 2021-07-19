CREATE TABLE [dbo].[Producto] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [CodigoBarra]         NVARCHAR (MAX)  NULL,
    [Descripcion]         NVARCHAR (MAX)  NULL,
    [Precio]              DECIMAL (18, 2) NOT NULL,
    [StockActual]         INT             NOT NULL,
    [CategoriaProductoId] INT             NOT NULL,
    [FotoProducto]        VARCHAR(MAX) NULL,
    CONSTRAINT [PK_dbo.Producto] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Producto_dbo.CategoriaProducto_CategoriaProductoId] FOREIGN KEY ([CategoriaProductoId]) REFERENCES [dbo].[CategoriaProducto] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CategoriaProductoId]
    ON [dbo].[Producto]([CategoriaProductoId] ASC);

