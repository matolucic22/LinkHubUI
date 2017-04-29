using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBs
    {
        private LinkHubDbEntities db;

        public UserBs()
        {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_User> GetALL()
        {
            return db.tbl_User.ToList();
        }

        public tbl_User GetByID(int Id)
        {
            return db.tbl_User.Find(Id);
        }
        void Insert(tbl_User url)
        {
            db.tbl_User.Add(url);
            Save();
        }

        void Delete(int Id)
        {
            tbl_User url = db.tbl_User.Find(Id);
            db.tbl_User.Remove(url);
            Save();
        }
        void Update(tbl_User url)
        {
            db.Entry(url).State = System.Data.Entity.EntityState.Modified;
        }
        void Save()
        {
            db.SaveChanges();
        }
    }
}
