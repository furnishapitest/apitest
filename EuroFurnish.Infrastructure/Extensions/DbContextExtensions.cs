using EuroFurnish.ApplicationCore.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroFurnish.Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
        public static IQueryable<T> GetActive<T>(this IQueryable<T> query) where T : BaseEntity, IAuditEntity
        {
            return query.Where(e => e.IsActive && !e.IsDeleted);
        }
        public static IQueryable<T> GetPassive<T>(this IQueryable<T> query) where T : BaseEntity, IAuditEntity
        {
            return query.Where(e => !e.IsActive);
        }
        public static IQueryable<T> GetDeleted<T>(this IQueryable<T> query) where T : BaseEntity, IAuditEntity
        {
            return query.Where(e => !e.IsDeleted);
        }
        public static IQueryable<T> GetActive<T>(this DbSet<T> query) where T :class,IAuditEntity
        {
            return query.Where(e => e.IsActive && !e.IsDeleted);
        }
        public static IQueryable<T> GetPassive<T>(this DbSet<T> query) where T : class, IAuditEntity
        {
            return query.Where(e => !e.IsActive);
        }
        public static IQueryable<T> GetDeleted<T>(this DbSet<T> query) where T : class, IAuditEntity
        {
            return query.Where(e => !e.IsDeleted);
        }
    }
}
