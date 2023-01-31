namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES(1, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(2, 'Action')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(3, 'Family')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(4, 'Romance')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(5, 'Drama')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(6, 'Horror')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(7, 'Thriller')");
        }

        public override void Down()
        {
        }
    }
}
