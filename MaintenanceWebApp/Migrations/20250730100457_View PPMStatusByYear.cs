using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ViewPPMStatusByYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                Create or alter view PPMStatusByYears as
                    select 
                    ROW_NUMBER() OVER (
                        PARTITION BY YEAR(TargetDate)
                        ORDER BY YEAR(TargetDate)
                    ) as RowNum,
                    Count(*) as Tasks, YEAR(TargetDate) as 'Year', 
                    Case when [Level] = 0 then 'Request'
                    when [Level] = 1 then 'Approved by Manager'
                    when [Level] = 2 then 'Approved by Terminal Manager'
                    when [Level] = 3 then 'On Progress'
                    when [Level] = 4 then 'Checking'
                    when [Level] = 5 then 'Completed'
                    when [Level] = 6 then 'Rejected' 
                    else 'Invalid' end as Status from ppmtasks
                    where DateCreated is not null and TargetDate is not null
                    group by [Level], YEAR(TargetDate)
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                drop view PPMStatusByYears;
                ");
        }
    }
}
