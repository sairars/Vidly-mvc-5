namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'72815372-1343-44af-b8d1-9d554cf4e828', N'admin@vidly.com', 0, N'AOgsrulp1fR/CgvQuGK2igJaWdyR5iCeHYtxQSF+8/QbqqZOcgcRD7fBDLgZPG2twQ==', N'59da2da4-f259-4de3-a520-b58fd73fb4c1', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ba6c8762-f9d2-421c-b9ba-af0c348ae998', N'guest@vidly.com', 0, N'AIAGhbe/MDZSi348nFxl/Xdd82hLwLwCvCltw1wQRD4vjl7Ga910+URwIK1Z3djcqQ==', N'b04d61b2-1944-4917-ba9e-fcff5a15c6cf', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ff588f5e-a9c1-4882-a6f9-5f951d706389', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'72815372-1343-44af-b8d1-9d554cf4e828', N'ff588f5e-a9c1-4882-a6f9-5f951d706389')
");
        }
        
        public override void Down()
        {
        }
    }
}
