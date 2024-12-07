using probiotics.Models;
using Microsoft.EntityFrameworkCore;
using Tag = probiotics.Models.Tag;

namespace probiotics.Data;

public class ApplicationDBContext: DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
    {
        
    }
    
    public DbSet<Algorithm> Algorithms { get; set; }
    public DbSet<Label> Labels { get; set; }
    public DbSet<AlgoLabel> AlgoLabels { get; set; }
    
    public DbSet<Swallow> Swallow { get; set; }
    public DbSet<SwallowLink> SwallowLinks { get; set; }
    public DbSet<Spend> Spend { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<Picture> Picture { get; set; }
    public DbSet<SpendTag> SpendTag { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 配置 Spend 和 Tag 的多对多关系
        modelBuilder.Entity<SpendTag>()
            .HasKey(st => new { st.SpendId, st.TagId }); // 联合主键

        modelBuilder.Entity<SpendTag>()
            .HasOne(st => st.Spend)
            .WithMany(s => s.SpendTags)
            .HasForeignKey(st => st.SpendId);

        modelBuilder.Entity<SpendTag>()
            .HasOne(st => st.Tag)
            .WithMany(t => t.SpendTags)
            .HasForeignKey(st => st.TagId);
        
        modelBuilder.Entity<AlgoLabel>()
            .HasKey(st => new { st.AlgorithmId, st.LabelId }); // 联合主键

        modelBuilder.Entity<AlgoLabel>()
            .HasOne(st => st.Algorithm)
            .WithMany(s => s.AlgoLabels)
            .HasForeignKey(st => st.AlgorithmId);

        modelBuilder.Entity<AlgoLabel>()
            .HasOne(st => st.Label)
            .WithMany(t => t.AlgoLabels)
            .HasForeignKey(st => st.LabelId);

        // 配置 Spend 和 Picture 的一对多关系
        modelBuilder.Entity<Picture>()
            .HasOne(p => p.Spend)
            .WithMany(s => s.Pictures)
            .HasForeignKey(p => p.SpendId);

        base.OnModelCreating(modelBuilder);
    }

}