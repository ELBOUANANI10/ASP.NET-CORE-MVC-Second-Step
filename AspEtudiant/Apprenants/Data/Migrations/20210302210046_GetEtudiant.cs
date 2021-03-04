using Microsoft.EntityFrameworkCore.Migrations;

namespace Apprenants.Data.Migrations
{
    public partial class GetEtudiant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string proc = @"CREATE PROCEDURE GetEtudiant
               	@id int 
                 AS
                 Begin
                 Select * from Etudiants where id=@id
                 end";
            migrationBuilder.Sql(proc);
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string proc = @"Drop PROCEDURE GetEtudiant";
       
            migrationBuilder.Sql(proc);
        }
    }
}
