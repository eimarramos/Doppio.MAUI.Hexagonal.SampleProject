using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Persistence.Interceptors
{
    public class CartTotalInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateTotal(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateTotal(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateTotal(DbContext? context)
        {
            if (context == null) return;


            foreach (var entry in context.ChangeTracker.Entries<CartEntity>())
            {
                var cart = entry.Entity;

                var hasChanges = context.ChangeTracker.Entries<CartDetailEntity>()
                                                      .Any(cd => cd.Entity.CartId == cart.Id &&
                                                                 (cd.State == EntityState.Added ||
                                                                 cd.State == EntityState.Modified ||
                                                                 cd.State == EntityState.Deleted));

                if (hasChanges)
                {
                    cart.Total = cart.CartDetails.Sum(item => item.Quantity * item.Coffee!.Price);
                }
            }
        }
    }
    /**
     * 
     * This function is used to check if the entity has changed owned entities.
     * Don't detect all changes.
     *
     **/
    public static class Extensions
    {
        public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
            entry.References.Any(r =>
                r.TargetEntry != null &&
                r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added ||
             r.TargetEntry.State == EntityState.Modified ||
             r.TargetEntry.State == EntityState.Deleted));
    }
}
