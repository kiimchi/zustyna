﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class donutCRUD
    {
        public donutCRUD()
        {
        }

        static public bool addDonut(int id, int? amount, string name, string fill, int? cost)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {

                if (GetDonut(id) == null && amount >= 0)
                {
                    donut newDonut = new donut
                    {
                        donut_id = id,
                        donut_name = name,
                        filling = fill,
                        price = cost,
                        quantity = amount,

                    };
                    context.donut.InsertOnSubmit(newDonut);
                    context.SubmitChanges();

                    return true;
                }
            }
            return false;
                
        }


        static public bool deleteDonut(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                donut mydonut = context.donut.SingleOrDefault(donut => donut.donut_id == id); //tu patrzyłam na różne metody żeby zmienić ale tylko ta się nadaje
                context.donut.DeleteOnSubmit(mydonut);
                context.SubmitChanges();
                return true;
            }
        }

        static public bool updateFilling (int id, string fill)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                donut mydonut = context.donut.SingleOrDefault(donut => donut.donut_id == id);
                mydonut.filling = fill;
                context.SubmitChanges();
                return true;
            }
        }

        static public bool updateName(int id, string name)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                donut mydonut = context.donut.SingleOrDefault(donut => donut.donut_id == id);
                mydonut.donut_name = name;
                context.SubmitChanges();
                return true;
            }
        }
        static public bool updatePrice(int id, int? cost)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                donut mydonut = context.donut.SingleOrDefault(donut => donut.donut_id == id);
                mydonut.price = cost;
                context.SubmitChanges();
                return true;
            }
        }
        static public bool updateQuantity(int id, int? amount) 
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                donut mydonut = context.donut.SingleOrDefault(donut => donut.donut_id == id);
                mydonut.quantity = amount;
                context.SubmitChanges();
                return true;
            }
        }

        static public donut GetDonut(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (donut donut in context.donut.ToList())
                {
                    if (donut.donut_id == id)
                    {
                        return donut;
                    } 
                }
                return null;
            }
        }

        static public List<Dictionary<string,string>> GetDonutsInfo()
   
        {
            List<Dictionary<string, string>> returnList = new List<Dictionary<string, string>>();
            List<donut> tempDonuts = GetAllDonuts().ToList();
            foreach (donut donut in tempDonuts)
            {
                Dictionary<string, string> temp = new Dictionary<string, string>();
                temp.Add("name",donut.donut_name);
                    temp.Add("id", donut.donut_id.ToString());
                temp.Add("filling",donut.filling);
                temp.Add("price", donut.price.ToString());
                temp.Add("quantity", donut.quantity.ToString());

                returnList.Add(temp);

            }
            return returnList;
        }
        static public Dictionary<string, string> GetDonutInfo(int donut_id)

        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            donut t = GetDonut(donut_id);
         
                temp.Add("name", t.donut_name);
                temp.Add("id", t.donut_id.ToString());
                temp.Add("filling", t.filling);
                temp.Add("price", t.price.ToString());
                temp.Add("quantity", t.quantity.ToString());

            
            return temp;
        }

        static public donut GetDonutByName(string name)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (donut donut in context.donut.ToList())
                {
                    if (donut.donut_name == name)
                    {
                        return donut;
                    }
                }
                return null;
            }
        }

        static public IEnumerable<donut> GetAllDonuts()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())  
            {
                var result = context.donut.ToList();
                return result;
            }
        }

        static public IEnumerable<donut> GetDuntsByFilling(string fill)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<donut> result = new List<donut>();
                foreach (donut donut in context.donut)
                {
                    if (donut.filling.Equals(fill))
                    {
                        result.Add(donut);
                    }
                }
                return result;
            }
        }
    }
}
