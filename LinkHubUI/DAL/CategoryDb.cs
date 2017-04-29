using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CategoryDb
    {
        private LinkHubDbEntities db;

        public CategoryDb()
        {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_Category> GetALL()
        {
            return db.tbl_Category.ToList();
        }

        public tbl_Category GetByID(int Id)
        {
            return db.tbl_Category.Find(Id);
        }
        void Insert(tbl_Category url)
        {
            db.tbl_Category.Add(url);
            Save();
        }

        void Delete(int Id)
        {
            tbl_Category url = db.tbl_Category.Find(Id);
            db.tbl_Category.Remove(url);
            Save();
        }
        void Update(tbl_Category url)
        {
            db.Entry(url).State = System.Data.Entity.EntityState.Modified;
        }
        void Save()
        {
            db.SaveChanges();
        }
    }
}
