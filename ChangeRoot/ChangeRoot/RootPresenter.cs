using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeRoot.Properties;

namespace ChangeRoot
{
    public class RootPresenter
    {
        public List<User> LoadData()
        {
            var users=new List<User>();
            var results=new DataTable();
            using (var conn=new SqlConnection(Settings.Default.ConnectionString))
            {
                string query = @"
                        select 
                            user_id as UserId,
	                    	name as Name,
	                    	sys_user as LogName
                        from dic_user
                                            ";
                using (var command = new SqlCommand(query, conn))
                using (var dataAdapter = new SqlDataAdapter(command))
                    dataAdapter.Fill(results);
            }
            foreach (var row in results.Rows)
            {
               var user = (DataRow)row;
               users.Add(new User()
                {
                    UserId = Convert.ToInt32(user.ItemArray[0]),
                    LogIn = user.ItemArray[2].ToString(),
                    Name = user.ItemArray[1].ToString()
                });
            }
            return users;
        }

        public List<Route> GetUserRoutes(int userId)
        {
            var routes = new List<Route>();
            var results = new DataTable();
            using (var conn = new SqlConnection(Settings.Default.ConnectionString))
            {
                string query = $@"
                        select 
	                        r.iRouteID,
	                        r.vcName,
	                        ru.iRouteGroupID
                        from
                            dic_Route r 
                            join dic_RouteUser ru on r.irouteId=ru.iRouteGroupID 
                        where ru.iUserID={userId}
                                            ";
                using (var command = new SqlCommand(query, conn))
                using (var dataAdapter = new SqlDataAdapter(command))
                    dataAdapter.Fill(results);
            }
            foreach (var row in results.Rows)
            {
                var route = (DataRow) row;
                routes.Add(new Route()
                {
                    RouteId = Convert.ToInt32(route.ItemArray[0]),
                    RouteName = route.ItemArray[1].ToString()
                });
            }
            return routes;
        }
    }
}
