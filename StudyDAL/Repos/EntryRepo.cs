using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyDAL.EF;
using StudyDAL.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace StudyDAL.Repos
{
    public class EntryRepo : IDisposable
    {
        public EntryRepo()
        {
            Table = Context.Entries;
        }

        public StudyEntities Context { get; } = new StudyEntities();
        private DbSet<Entry> Table;

        public Entry GetOne(int? id) => Table.Find(id);
        public Task<Entry> GetOneAsync(int? id) => Table.FindAsync(id);

        public List<Entry> GetAll() => Table.ToList();
        public Task<List<Entry>> GetAllAsync() => Table.ToListAsync();

        public int Add(Entry entity)
        {
            Table.Add(entity);
            return SaveChanges();
        }

        public Task<int> AddAsync(Entry entity)
        {
            Table.Add(entity);
            return SaveChangesAsync();
        }

        public int AddRange(IList<Entry> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }

        public Task<int> AddRangeAsync(IList<Entry> entities)
        {
            Table.AddRange(entities);
            return SaveChangesAsync();
        }

        public int Save(Entry entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public Task<int> SaveAsync(Entry entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        public int Delete(Entry entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(Entry entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

        public int Delete(int id)
        {
            Context.Entry(new Entry() { EntryID = id }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new Entry() { EntryID = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

        internal int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (CommitFailedException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (CommitFailedException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                Context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
