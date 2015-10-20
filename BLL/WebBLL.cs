using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace BLL
{
    public class WebBLL
    {
        /// <summary>
        /// Gets the cherry.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/9
        /// 描述：通过Code获取信息
        public static List<Model.BestCherryInfo> GetCherry(string code)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                var list = (from u in entitys.BestCherryInfoes select u).Where(a => a.CODE == code).Take(1).ToList();
                return list;
            }
        }

        /// <summary>
        /// Gets the normal cherry.
        /// </summary>
        /// <param name="activityID">The activity identifier.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/17
        /// 描述：获取单个正常活动下的所有普通商品
        public static List<Model.BestCherryInfo> GetNormalCherry(Guid activityID)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                var activityProList = (from u in entitys.ActivityProes select u).Where(a => a.ACTIVITYID == activityID).ToList();
                List<Model.BestCherryInfo> list = new List<BestCherryInfo>();
                foreach (ActivityPro item in activityProList)
                {
                    list.Add((from u in entitys.BestCherryInfoes select u).Where(a => a.CODE == item.PROCODE).ToList()[0]);
                }
                return list;
            }
        }

        /// <summary>
        /// Gets the cherry.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/14
        /// 描述：通过ID来获取商品信息
        public static List<Model.BestCherryInfo> GetCherry(Guid ID)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                var list = (from u in entitys.BestCherryInfoes select u).Where(a => a.ID == ID).Take(1).ToList();
                return list;
            }
        }

        /// <summary>
        /// Gets all product.
        /// </summary>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/10
        /// 描述：获取所有商品
        public static List<Model.BestCherryInfo> GetAllProduct()
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                var list = (from u in entitys.BestCherryInfoes select u).ToList();
                return list;
            }
        }

        /// <summary>
        /// Gets the activity.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/10
        /// 描述：通过Code获取活动
        public static List<Model.Activity> GetActivity(string code)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                var list = (from u in entitys.Activities select u).Where(a => a.CODE == code).ToList();
                return list;
            }
        }

        /// <summary>
        /// Gets the activity pro.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/14
        /// 描述：通过CODE获取活动的商品设置信息
        public static List<Model.ActivityPro> GetActivityPro(string code, Guid activityid)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                var list = (from u in entitys.ActivityProes select u).Where(a => a.PROCODE == code).Where(a => a.ACTIVITYID == activityid).ToList();
                return list;
            }
        }

        /// <summary>
        /// Gets the activity pro.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/17
        /// 描述：通过ID获取活动的商品设置信息
        public static List<Model.ActivityPro> GetActivityPro(Guid id)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                var list = (from u in entitys.ActivityProes select u).Where(a => a.ID == id).ToList();
                return list;
            }
        }

        /// <summary>
        /// Checks the activity.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="activityid">The activityid.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/16
        /// 描述：检查参数
        public static bool CheckActivity(string code, Guid activityid,string type)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                int typeInt = int.Parse(type);
                var list = (from u in entitys.Activities select u).Where(a => a.TYPE == typeInt).Where(a => a.ID == activityid).ToList();
                var listPro = (from u in entitys.ActivityProes select u).Where(a => a.PROCODE == code).Where(a => a.ACTIVITYID == activityid).ToList();
                if (list.Count>0&listPro.Count>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets the success order information list by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/9
        /// 描述：获取成功的订单数量（限时购）
        public static int GetSuccessOrderInfoListByCode(string code)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                int count = (from u in entitys.OrderInfoes select u).Where(a => a.TYPE == 1).Where(a => a.ORDERLIST.Contains(code)).Where(a=>a.ISHISTORY==false).ToList().Count;
                return count;
            }
        }

        /// <summary>
        /// Gets the cherry.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/9
        /// 描述：通过手机号查询是否购买过促销商品(30分钟内)
        public static int GetSuccessOrderInfoListByMobile(string mobile)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                DateTime dt = DateTime.Now.AddMinutes(-30);
                int count1 = (from u in entitys.OrderInfoes select u).Where(a => a.TYPE == 1).Where(a => a.MOBILE.Contains(mobile)).Where(a=>a.SENDORDERTIME>=dt).ToList().Count;
                int count2 = (from u in entitys.OrderInfoes select u).Where(a => a.TYPE == 1).Where(a => a.MOBILE.Contains(mobile)).Where(a =>a.INTERFACE==true).ToList().Count;
                return count1+count2;
            }
        }

        /// <summary>
        /// Inserts the order.
        /// </summary>
        /// <param name="consignee">The consignee.</param>
        /// <param name="membernum">The membernum.</param>
        /// <param name="mobile">The mobile.</param>
        /// <param name="receiver_state">The receiver_state.</param>
        /// <param name="receiver_city">The receiver_city.</param>
        /// <param name="receiver_district">The receiver_district.</param>
        /// <param name="address">The address.</param>
        /// <param name="orderlist">The orderlist.</param>
        /// <param name="orderid">The orderid.</param>
        /// <param name="allPrice">All price.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/10
        /// 描述：提交订单信息
        public static bool InsertOrder(string consignee, string membernum, string mobile, string receiver_state, string receiver_city, string receiver_district, string address, string orderlist, string orderid, string allPrice, int type, Guid activityid,string remark)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                try
                {
                    OrderInfo oi = new OrderInfo();
                    oi.ID = Guid.NewGuid();
                    oi.SENDORDERTIME = DateTime.Now;
                    oi.CONSIGNEE = consignee;
                    oi.MOBILE = mobile;
                    oi.MEMBERNUM = membernum;
                    oi.RECEIVER_STATE = receiver_state;
                    oi.RECEIVER_CITY = receiver_city;
                    oi.RECEIVER_DISTRICT = receiver_district;
                    oi.ADDRESS = address;
                    oi.ORDERLIST = orderlist;
                    oi.INTERFACE = false;
                    oi.INTERSUCCES = false;
                    oi.ORDERID = orderid;
                    oi.ALLPRICE = int.Parse(allPrice);
                    oi.TYPE = type;
                    oi.ACTIVITYID = activityid;
                    oi.ISHISTORY = false;
                    oi.REMARK = remark;
                    entitys.OrderInfoes.Add(oi);
                    entitys.SaveChanges();
                    return true;
                }
                catch (DbEntityValidationException dbEx)
                {
                    return false;
                    throw;
                }
            }
        }

        public static bool UpdatePayOrder(bool inter, bool intersuccess, string orderid, string paydate, string usernum, string amount)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                List<OrderInfo> orderInfoList = (from a in entitys.OrderInfoes select a).Where(a => a.ORDERID == orderid).ToList();
                try
                {
                    OrderInfo oi = orderInfoList[0];
                    oi.INTERFACE = inter;
                    oi.INTERSUCCES = intersuccess;
                    oi.PAYDATE = paydate;
                    oi.USERNUM = usernum;
                    oi.AMOUNT = int.Parse(amount);
                    //将实体对象加入EF对象容器中，并获取伪包装类对象
                    DbEntityEntry<OrderInfo> entry = entitys.Entry<OrderInfo>(oi);
                    //将包装类对象 的状态设置为 Unchanged
                    entry.State = System.Data.Entity.EntityState.Modified;
                    entry.Property(a => a.INTERFACE).IsModified = true;
                    entry.Property(a => a.INTERSUCCES).IsModified = true;
                    entry.Property(a => a.PAYDATE).IsModified = true;
                    entry.Property(a => a.USERNUM).IsModified = true;
                    entry.Property(a => a.AMOUNT).IsModified = true;
                    entitys.SaveChanges();
                    return true;
                }
                catch (DbEntityValidationException dbEx)
                {
                    return false;
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the cherry.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/10
        /// 描述：通过名称来查找商品
        public static List<Model.BestCherryInfo> GetCherryByName(string name)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                List<Model.BestCherryInfo> list;
                list = (from u in entitys.BestCherryInfoes select u).Where(a => a.TITLE.Contains(name)).ToList();
                return list;
            }
        }

        /// <summary>
        /// Gets the name of the activity by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/11
        /// 描述：根据名称和类型来查找活动
        public static List<Model.Activity> GetActivityByName(string name, int type)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                List<Model.Activity> list;
                list = (from u in entitys.Activities select u).Where(a => a.NAME.Contains(name)).Where(a => a.TYPE == type).ToList();
                return list;
            }
        }

        /// <summary>
        /// Deletes the activity.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/16
        /// 描述：根据ID删除活动
        public static bool DelActivity(Guid ID)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                List<Activity> activityList = (from a in entitys.Activities select a).Where(a => a.ID == ID).ToList();
                try
                {
                    if (activityList.Count >= 1)
                    {
                        Activity deleteActivity = activityList[0];
                        entitys.Activities.Attach(deleteActivity);
                        entitys.Activities.Remove(deleteActivity);
                        entitys.SaveChanges();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
        }

        /// <summary>
        /// Resets the activity.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/16
        /// 描述：重置活动 开启新的抢购
        public static bool ResetActivity(Guid ID)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                try
                {
                    List<Model.OrderInfo> orderList = (from a in entitys.OrderInfoes select a).Where(a => a.ACTIVITYID == ID).ToList();
                    if (orderList.Count != 0)
                    {
                        foreach (Model.OrderInfo item in orderList)
                        {
                            OrderInfo order = item;
                            order.ISHISTORY = true;
                            //将实体对象加入EF对象容器中，并获取伪包装类对象
                            DbEntityEntry<OrderInfo> entry = entitys.Entry<OrderInfo>(order);
                            //将包装类对象 的状态设置为 Unchanged
                            entry.State = System.Data.Entity.EntityState.Modified;
                            entry.Property(a => a.ISHISTORY).IsModified = true;
                            entitys.SaveChanges();
                        }
                    }
                    return true;
                }
                catch (DbEntityValidationException dbEx)
                {
                    return false;
                    throw;
                }
            }
        }

        /// <summary>
        /// Updates the type of the icbc cherry information and.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="title">The title.</param>
        /// <param name="color">The color.</param>
        /// <param name="price">The price.</param>
        /// <param name="memberprice">The memberprice.</param>
        /// <param name="imgpath">The imgpath.</param>
        /// <param name="smalltitle">The smalltitle.</param>
        /// <param name="code">The code.</param>
        /// <param name="des">The DES.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/10
        /// 描述：插入商品信息
        public static bool InsertICBCCherryInfo(string title, string color, string price, string memberprice, string imgpath, string smalltitle, string code, string des)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                try
                {
                    BestCherryInfo bci = new BestCherryInfo();
                    bci.ID = Guid.NewGuid();
                    bci.TITLE = title;
                    bci.COLOR = color;
                    bci.PRICE = int.Parse(price);
                    bci.MEMBERPRICE = int.Parse(memberprice);
                    bci.IMAGEPATH = imgpath;
                    bci.SMALLTITLE = smalltitle;
                    bci.CODE = code;
                    entitys.BestCherryInfoes.Add(bci);
                    entitys.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
        }

        /// <summary>
        /// Updates the icbc cherry information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="title">The title.</param>
        /// <param name="color">The color.</param>
        /// <param name="price">The price.</param>
        /// <param name="memberprice">The memberprice.</param>
        /// <param name="imgpath">The imgpath.</param>
        /// <param name="smalltitle">The smalltitle.</param>
        /// <param name="code">The code.</param>
        /// <param name="des">The DES.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/10
        /// 描述：更新商品信息
        public static bool UpdateICBCCherryInfo(Guid id, string title, string color, string price, string memberprice, string imgpath, string smalltitle, string code, string des)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                try
                {
                    BestCherryInfo bci = new BestCherryInfo();
                    bci.ID = id;
                    bci.TITLE = title;
                    bci.COLOR = color;
                    bci.PRICE = int.Parse(price);
                    bci.MEMBERPRICE = int.Parse(memberprice);
                    bci.IMAGEPATH = imgpath;
                    bci.SMALLTITLE = smalltitle;
                    bci.CODE = code;
                    //将实体对象加入EF对象容器中，并获取伪包装类对象
                    DbEntityEntry<BestCherryInfo> entry = entitys.Entry<BestCherryInfo>(bci);
                    //将包装类对象 的状态设置为 Unchanged
                    entry.State = System.Data.Entity.EntityState.Modified;
                    entry.Property(a => a.TITLE).IsModified = true;
                    entry.Property(a => a.CODE).IsModified = true;
                    entry.Property(a => a.COLOR).IsModified = true;
                    entry.Property(a => a.PRICE).IsModified = true;
                    entry.Property(a => a.MEMBERPRICE).IsModified = true;
                    entry.Property(a => a.IMAGEPATH).IsModified = true;
                    entry.Property(a => a.SMALLTITLE).IsModified = true;
                    entitys.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
        }

        /// <summary>
        /// Inserts the activity.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="buytime">The buytime.</param>
        /// <param name="num">The number.</param>
        /// <param name="type">The type.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/10
        /// 描述：新增活动
        public static bool InsertActivity(string name, string type, string code)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                try
                {
                    Activity att = new Activity();
                    att.ID = Guid.NewGuid();
                    att.NAME = name;
                    att.TYPE = int.Parse(type);
                    att.CODE = code;
                    entitys.Activities.Add(att);
                    entitys.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
        }

        /// <summary>
        /// Updates the activity.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="buytime">The buytime.</param>
        /// <param name="num">The number.</param>
        /// <param name="type">The type.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/10
        /// 描述：编辑活动
        public static bool UpdateActivity(Guid id, string name, string type, string code)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                try
                {
                    Activity att = new Activity();
                    att.NAME = name;
                    att.TYPE = int.Parse(type);
                    att.CODE = code;
                    att.ID = id;
                    //将实体对象加入EF对象容器中，并获取伪包装类对象
                    DbEntityEntry<Activity> entry = entitys.Entry<Activity>(att);
                    //将包装类对象 的状态设置为 Unchanged
                    entry.State = System.Data.Entity.EntityState.Modified;
                    entry.Property(a => a.NAME).IsModified = true;
                    entry.Property(a => a.TYPE).IsModified = true;
                    entry.Property(a => a.CODE).IsModified = true;
                    entitys.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
        }

        public static bool UpdateActivityPro(Guid id, string buytime, string num, string imagepath, string desimgpath)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                try
                {
                    List<ActivityPro> list = entitys.ActivityProes.Where(a => a.ID == id).ToList();
                    if (list.Count>0)
                    {
                        ActivityPro att = list[0];
                        att.BUYTIME = buytime;
                        att.NUM = int.Parse(num);
                        att.IMAGEPATH = imagepath;
                        att.DESIMGPATH = desimgpath;
                        //将实体对象加入EF对象容器中，并获取伪包装类对象
                        DbEntityEntry<ActivityPro> entry = entitys.Entry<ActivityPro>(att);
                        entry.State = System.Data.Entity.EntityState.Modified;
                        entitys.SaveChanges();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
        }

        /// <summary>
        /// Inserts the activity pro.
        /// </summary>
        /// <param name="activityID">The activity identifier.</param>
        /// <param name="procode">The procode.</param>
        /// <param name="proid">The proid.</param>
        /// <param name="buytime">The buytime.</param>
        /// <param name="num">The number.</param>
        /// <param name="imagepath">The imagepath.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/11
        /// 描述：插入活动商品
        public static bool InsertActivityPro(Guid activityID, string procode, Guid proid, string buytime, string num, string imagepath,string desimgpath)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                try
                {
                    ActivityPro att = new ActivityPro();
                    att.ID = Guid.NewGuid();
                    att.ACTIVITYID = activityID;
                    att.PROCODE = procode;
                    att.PROID = proid;
                    att.BUYTIME = buytime;
                    att.NUM = int.Parse(num);
                    att.IMAGEPATH = imagepath;
                    att.DESIMGPATH = desimgpath;
                    entitys.ActivityProes.Add(att);
                    entitys.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
        }

        /// <summary>
        /// Updates the poll.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="title">The title.</param>
        /// <param name="color">The color.</param>
        /// <param name="price">The price.</param>
        /// <param name="memberprice">The memberprice.</param>
        /// <param name="imgpath">The imgpath.</param>
        /// <param name="smalltitle">The smalltitle.</param>
        /// <param name="code">The code.</param>
        /// <param name="des">The DES.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/14
        /// 描述：更新投票数
        public static bool UpdatePoll(Guid ID)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                try
                {
                    List<Model.BestCherryInfo> list = WebBLL.GetCherry(ID);
                    if (list.Count != 0)
                    {
                        BestCherryInfo bci = list[0];
                        int poll = 0;
                        if (list[0].POLL != null)
                        {
                            poll = (int)list[0].POLL;
                        }
                        bci.POLL = poll + 1;
                        //将实体对象加入EF对象容器中，并获取伪包装类对象
                        DbEntityEntry<BestCherryInfo> entry = entitys.Entry<BestCherryInfo>(bci);
                        //将包装类对象 的状态设置为 Unchanged
                        entry.State = System.Data.Entity.EntityState.Modified;
                        entry.Property(a => a.POLL).IsModified = true;
                        entitys.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    return false;
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the type of the activityes by.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/14
        /// 描述：按类型找活动
        public static List<Model.Activity> GetActivityesByType(int type)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                List<Model.Activity> list;
                list = (from u in entitys.Activities select u).Where(a => a.TYPE == type).ToList();
                return list;
            }
        }

        /// <summary>
        /// Gets the name of the order information list by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="activityID">The activity identifier.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/14
        /// 描述：通过名称和活动类型来获取订单列表(加了上了时间）
        public static List<Model.OrderInfo> GetOrderInfoListByName(string name, Guid activityID, bool isPay,string time)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                List<Model.OrderInfo> list;
                list = (from u in entitys.OrderInfoes select u).Where(a => a.CONSIGNEE.Contains(name)).Where(a=>a.PAYDATE.Contains(time)).Where(a => a.ACTIVITYID == activityID).Where(a => a.INTERFACE == isPay).OrderByDescending(a=>a.SENDORDERTIME).ToList();
                return list;
            }
        }

        /// <summary>
        /// Gets the name of the order information list by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="activityID">The activity identifier.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/14
        /// 描述：通过名称和活动类型来获取订单列表
        public static List<Model.OrderInfo> GetOrderInfoListByName(string name, Guid activityID, bool isPay)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                List<Model.OrderInfo> list;
                list = (from u in entitys.OrderInfoes select u).Where(a => a.CONSIGNEE.Contains(name)).Where(a => a.ACTIVITYID == activityID).Where(a => a.INTERFACE == isPay).OrderByDescending(a => a.SENDORDERTIME).ToList();
                return list;
            }
        }

        /// <summary>
        /// Gets the order information list by name order by have printed.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="activityID">The activity identifier.</param>
        /// <param name="isPay">if set to <c>true</c> [is pay].</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/23
        /// 描述：通过名称和活动类型来获取订单列表(按未打印排序)
        public static List<Model.OrderInfo> GetOrderInfoListByNameOrderByNotPrinted(string name, Guid activityID, bool isPay,bool isPrinted)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                List<Model.OrderInfo> list;
                list = (from u in entitys.OrderInfoes select u).Where(a => a.CONSIGNEE.Contains(name)).Where(a => a.ACTIVITYID == activityID).Where(a => a.INTERFACE == isPay).Where(a=>a.ISPRINTED==isPrinted).OrderByDescending(a=>a.ISPRINTED).OrderByDescending(a => a.SENDORDERTIME).ToList();
                return list;
            }
        }

        /// <summary>
        /// Deletes the activity pro.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/14
        /// 描述：删除活动商品
        public static bool DeleteActivityPro(Guid ID)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                List<ActivityPro> activityProList = (from a in entitys.ActivityProes select a).Where(a => a.ID == ID).ToList();
                try
                {
                    if (activityProList.Count >= 1)
                    {
                        ActivityPro deleteActivityProes = activityProList[0];
                        entitys.ActivityProes.Attach(deleteActivityProes);
                        entitys.ActivityProes.Remove(deleteActivityProes);
                        entitys.SaveChanges();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the order information not pay.
        /// </summary>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/17
        /// 描述：未付款订单数
        public static int GetOrderInfoNotPay()
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                int count = (from o in entitys.OrderInfoes select o).Where(o => o.INTERFACE == false).Where(o => o.SENDORDERTIME.Value.Day == DateTime.Now.Day).Where(o => o.SENDORDERTIME.Value.Month == DateTime.Now.Month).GroupBy(o => new { o.CONSIGNEE, o.MOBILE, o.RECEIVER_STATE, o.RECEIVER_CITY, o.RECEIVER_DISTRICT, o.ADDRESS, o.ORDERLIST }).ToList().Count;
                return count;
            }
        }


        /// <summary>
        /// Gets the order information have pay.
        /// </summary>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/17
        /// 描述：已付款数
        public static int GetOrderInfoHavePay()
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                string dt = DateTime.Now.ToString("yyyyMMdd");
                int count = (from o in entitys.OrderInfoes select o).Where(o => o.PAYDATE.Contains(dt)).Where(o => o.INTERFACE == true).ToList().Count;
                return count;
            }
           
        }

        /// <summary>
        /// Gets the order information list by mobile.
        /// </summary>
        /// <param name="mobile">The mobile.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/18
        /// 描述：根据手机号查询已付款订单
        public static List<Model.OrderInfo> GetOrderInfoListByMobile(string mobile)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                List<Model.OrderInfo> list;
                list = (from u in entitys.OrderInfoes select u).Where(a => a.MOBILE==mobile).Where(a => a.INTERFACE == true).OrderByDescending(a => a.PAYDATE).ToList();
                return list;
            }
        }

        /// <summary>
        /// Updates the logistics.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="logistics">The logistics.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/23
        /// 描述：更新物流单号
        public static bool UpdateLogistics(Guid id,string logistics)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                List<OrderInfo> orderInfoList = (from a in entitys.OrderInfoes select a).Where(a => a.ID == id).ToList();
                try
                {
                    OrderInfo oi = orderInfoList[0];
                    oi.LOGISTICS = logistics;
                    oi.ISPRINTED = true;
                    //将实体对象加入EF对象容器中，并获取伪包装类对象
                    DbEntityEntry<OrderInfo> entry = entitys.Entry<OrderInfo>(oi);
                    //将包装类对象 的状态设置为 Unchanged
                    entry.State = System.Data.Entity.EntityState.Modified;
                    entry.Property(a => a.LOGISTICS).IsModified = true;
                    entry.Property(a => a.ISPRINTED).IsModified = true;
                    entitys.SaveChanges();
                    return true;
                }
                catch (DbEntityValidationException dbEx)
                {
                    return false;
                    throw;
                }
            }
        }
    }
}
