using Microsoft.EntityFrameworkCore;
using Helm_Budget_System.Models;

namespace Helm_Budget_System.Data;

public class Helm_Budget_DbContext : DbContext
{
    public Helm_Budget_DbContext(DbContextOptions<Helm_Budget_DbContext> options)
        : base(options)
    {
    }

    public DbSet<Helm_Budget_System.Models.UserRole> UserRole { get; set; }
    public DbSet<Helm_Budget_System.Models.School> School { get; set; }
    public DbSet<Helm_Budget_System.Models.Year> Year { get; set; }
    public DbSet<Helm_Budget_System.Models.BudgetSector> BudgetSector { get; set; }
    public DbSet<Helm_Budget_System.Models.DescriptorDescription> DescriptorDescription { get; set; }
    public DbSet<Helm_Budget_System.Models.DescriptorDesignation> DescriptorDesignation { get; set; }
    public DbSet<Helm_Budget_System.Models.ExpenseCategory> ExpenseCategory { get; set; }
    public DbSet<Helm_Budget_System.Models.PayrollCategory> PayrollCategory { get; set; }
    public DbSet<Helm_Budget_System.Models.RevenueCategory> RevenueCategory { get; set; }
    public DbSet<Helm_Budget_System.Models.TransactionDescriptor> TransactionDescriptor { get; set; }
    public DbSet<Helm_Budget_System.Models.TravelRateGroup> TravelRateGroup { get; set; }
    public DbSet<Helm_Budget_System.Models.Revenue> Revenue { get; set; }
    public DbSet<Helm_Budget_System.Models.Ticket> Ticket { get; set; }

    //public DbSet<Helm_Budget_System.Models.Expense> Expense { get; set; }

    // Travel Section Entities

    public DbSet<Helm_Budget_System.Models.TravelEntry> TravelEntry { get; set; }
    public DbSet<Helm_Budget_System.Models.TravelCategory> TravelCategory { get; set; }
    public DbSet<Helm_Budget_System.Models.TravelParty> TravelParty { get; set; }
    public DbSet<Helm_Budget_System.Models.TravelLodging> TravelLodging { get; set; }
    public DbSet<Helm_Budget_System.Models.TravelAirfare> TravelAirfare { get; set; }
    public DbSet<Helm_Budget_System.Models.TravelPerDiem> TravelPerDiem { get; set; }
    public DbSet<Helm_Budget_System.Models.TravelAuto> TravelAuto { get; set; }
    public DbSet<Helm_Budget_System.Models.TravelMiscellaneousExpense> TravelMiscellaneousExpense { get; set; }
}
