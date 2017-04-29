using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UrlBs
    {
        private LinkHubDbEntities db;

        public UrlBs()
        {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_Url> GetALL()
        {
            return db.tbl_Url.ToList();
        }

        public tbl_Url GetByID(int Id)
        {
            return db.tbl_Url.Find(Id);
        }
        public void Insert(tbl_Url url)
        {
            db.tbl_Url.Add(url);
            Save();
        }

        public void Delete(int Id)
        {
            tbl_Url url = db.tbl_Url.Find(Id);
            db.tbl_Url.Remove(url);
            Save();
        }
        public void Update(tbl_Url url)
        {
            db.Entry(url).State = System.Data.Entity.EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
