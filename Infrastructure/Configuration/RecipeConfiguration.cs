using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared;

namespace Infrastructure.Configuration;

public class RecipeConfiguration : BaseModelConfiguration<Recipe>
{
    public override void Configure(EntityTypeBuilder<Recipe> builder)
    {
        base.Configure(builder);
        builder.Property(c => c.Description).HasColumnType("varchar(200)");

    }
}
