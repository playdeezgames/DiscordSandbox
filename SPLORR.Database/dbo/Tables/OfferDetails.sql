CREATE TABLE [dbo].[OfferDetails]
(
	[OfferDetailId] INT NOT NULL IDENTITY(1,1),
	[OfferId] INT NOT NULL,
	[ItemTypeId] INT NOT NULL,
	[QuantityIn] INT NOT NULL,
	[QuantityOut] INT NOT NULL,
	CONSTRAINT PK_OfferDetails PRIMARY KEY(OfferDetailId),
	CONSTRAINT FK_OfferDetails_Offers FOREIGN KEY (OfferId) REFERENCES Offers(OfferId),
	CONSTRAINT FK_OfferDetails_ItemTypes FOREIGN KEY (ItemTypeId) REFERENCES ItemTypes(ItemTypeId),
	CONSTRAINT CK_OfferDetails_QuantityIn CHECK(QuantityIn>=0),
	CONSTRAINT CK_OfferDetails_QuantityOut CHECK(QuantityOut>=0),
	CONSTRAINT CK_OfferDetails_QuantityIn_QuantityOut CHECK(QuantityIn+QuantityOut>0),
	CONSTRAINT AK_OfferDetails_OfferId_ItemTypeId UNIQUE(OfferId, ItemTypeId)
)
