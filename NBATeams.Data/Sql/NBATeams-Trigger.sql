--Deletes the Player's Stats after deleting the Player

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:        <Author,,Name>
-- Create date: <Create Date,,>
-- Description:    <Description,,>
-- =============================================
CREATE TRIGGER OnDelete_StatsOfPlayer
   ON  Players
   AFTER DELETE
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for trigger here
    DELETE FROM [Stats] WHERE Id = (Select [Stats].Id From deleted where [Stats].Id = deleted.StatsId)

END
GO