using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoWeb.Appclass
{
    public class Data
    {
        private static AdoDataBase database;

        private static AdoDataBase DataBase
        {
            get
            {
                if(database==null)
                {
                    database = AdoDataBase.DataBases["PhotoWeb"];
                }
                return database;
            }
        }

        public static DataRow GetAlbum(int id)
        {
            string sql = "Select Top 1 * from [Album]  WHERE ID = @ID";

            List<DbParameter> parameters = new List<DbParameter>
                                           {
                                               DataBase.CreateInDbParameter("@ID",DbType.Int32, id),
                                           };

            DataTable dt = DataBase.ExecuteDataSet(sql, CommandType.Text, parameters).Tables[0];

            if (dt.Rows.Count > 0)
                return dt.Rows[0];

            return null;

        }

        public static DataSet SelectAllShowAlbum()
        {
            string sql = "Select * from [Album] where IsShow=1 order by SortIndex asc";

            List<DbParameter> parameters = new List<DbParameter>();

            return DataBase.ExecuteDataSet(sql, CommandType.Text, parameters);
        }


        public static DataSet SelectAllAlbum()
        {
            string sql = "Select * from [Album] order by IsShow desc,SortIndex asc";

            List<DbParameter> parameters = new List<DbParameter>();

            return DataBase.ExecuteDataSet(sql, CommandType.Text, parameters);
        }

        public static DataSet SelectAllPhoto(int aid)
        {
            string sql = "Select * from [Photo] where [AlbumID]=@AlbumID order by IsShow desc,SortIndex asc";

            List<DbParameter> parameters = new List<DbParameter>
                                           {
                                               DataBase.CreateInDbParameter("@AlbumID",DbType.Int32, aid),
                                           };

            return DataBase.ExecuteDataSet(sql, CommandType.Text, parameters);
        }

        public static void AddAlbum(string name, string description, bool isShow)
        {
            string sql =
                @"INSERT INTO [Album]
           ([Name]
           ,[Description]
           ,[CreateDate]
           ,[CreateBy]
           ,[ShowType]
           ,[SortIndex]
           ,[IsShow]
           ,[MusicUrl])
     VALUES
           (@Name
           ,@Description
           ,GetDate()
           ,null
           ,'1'
           ,999
           ,@IsShow
           ,null)";


            List<DbParameter> parameters = new List<DbParameter>
                                           {
                                               DataBase.CreateInDbParameter("@Name", name),
                                               DataBase.CreateInDbParameter("@Description", description),
                                               DataBase.CreateInDbParameter("@IsShow",DbType.Boolean, isShow),
                                           };

            DataBase.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        public static void UpdateAlbumShowAndSortIndex(int id, string name, string description, bool isShow, int sortIndex)
        {
            string sql =
                @"UPDATE [Album]
   SET
       [Name] = @Name
      ,[Description] = @Description
      ,[SortIndex] = @SortIndex
      ,[IsShow] = @IsShow
 WHERE ID = @ID";


            List<DbParameter> parameters = new List<DbParameter>
                                           {
                                               DataBase.CreateInDbParameter("@ID",DbType.Int32, id),
                                               DataBase.CreateInDbParameter("@Name", name),
                                               DataBase.CreateInDbParameter("@Description",description),
                                               DataBase.CreateInDbParameter("@SortIndex",DbType.Int32, sortIndex),
                                               DataBase.CreateInDbParameter("@IsShow",DbType.Boolean, isShow),
                                           };

            DataBase.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        public static void DeleteAlbum(int id)
        {
                        string sql =
                @"DELETE FROM  [Album]
 WHERE ID = @ID";


            List<DbParameter> parameters = new List<DbParameter>
                                           {
                                               DataBase.CreateInDbParameter("@ID",DbType.Int32, id),
                                           };

            DataBase.ExecuteNonQuery(sql, CommandType.Text, parameters);


            
        }

        public static void DeletePhoto(int id)
        {
            string sql =
    @"DELETE FROM  [Photo]
 WHERE ID = @ID";


            List<DbParameter> parameters = new List<DbParameter>
                                           {
                                               DataBase.CreateInDbParameter("@ID",DbType.Int32, id),
                                           };

            DataBase.ExecuteNonQuery(sql, CommandType.Text, parameters);



        }

        public static bool ThumbnailCallback()
        {
            return false;
        }


        public static void AddPhoto(int aID,string name, string description, bool isShow, HttpPostedFile file)
        {
            DateTime now = DateTime.Now;
            Random random = new Random();
            int number = random.Next(0, 999);

            string ext = Path.GetExtension(file.FileName);

            string nFileName = string.Format("N{0}{1}", now.ToString("yyyyMMddHHmmss"), number.ToString("D2")) + ext;
            string tFileName = string.Format("T{0}{1}", now.ToString("yyyyMMddHHmmss"), number.ToString("D2")) + ext;

            string path = HttpContext.Current.Server.MapPath("~/UploadFile/Photos/");

            file.SaveAs(Path.Combine(path, nFileName));

            Image image = Image.FromFile(Path.Combine(path, nFileName));

            Image.GetThumbnailImageAbort myCallback =
new Image.GetThumbnailImageAbort(ThumbnailCallback);


            image.GetThumbnailImage(110, 110, myCallback, IntPtr.Zero).Save(Path.Combine(path, tFileName));


            string sql =
                @"
            INSERT INTO  [Photo]
           ([AlbumID]
           ,[Url]
           ,[TUrl]
           ,[Name]
           ,[Description]
           ,[IsShow]
           ,[CreateBy]
           ,[CreateDate]
           ,[SetAsTitleImage]
           ,[SortIndex])
     VALUES
           (@AlbumID
           ,@Url
           ,@TUrl
           ,@Name
           ,@Description
           ,@IsShow
           ,NULL
           ,GetDATE()
           ,0
            ,999)";


            List<DbParameter> parameters = new List<DbParameter>
                                           {
                                               DataBase.CreateInDbParameter("@Name", name),
                                               DataBase.CreateInDbParameter("@Description", description),
                                               DataBase.CreateInDbParameter("@IsShow",DbType.Boolean, isShow),
                                               DataBase.CreateInDbParameter("@AlbumID",DbType.Int32, aID),
                                               DataBase.CreateInDbParameter("@Url",DbType.String, nFileName),
                                               DataBase.CreateInDbParameter("@TUrl",DbType.String, tFileName),
                                           };

            DataBase.ExecuteNonQuery(sql, CommandType.Text, parameters);










        }


        public static void SetPhotoAsTitle(int id,int aid)
        {
            string sql =
@"UPDATE [Photo] set SetAsTitleImage = 1 WHERE ID = @ID and AlbumID=@AlbumID;UPDATE [Photo] set SetAsTitleImage = 0 WHERE ID <> @ID and AlbumID=@AlbumID;";


            List<DbParameter> parameters = new List<DbParameter>
                                           {
                                               DataBase.CreateInDbParameter("@ID",DbType.Int32, id),
                                               DataBase.CreateInDbParameter("@AlbumID",DbType.Int32, aid),
                                           };

            DataBase.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }


        public static void UpdatePhotoShowAndSortIndex(int id, string name, string description, bool isShow, int sortIndex)
        {
            string sql =
                @"UPDATE [Photo]
   SET
       [Name] = @Name
      ,[Description] = @Description
      ,[SortIndex] = @SortIndex
      ,[IsShow] = @IsShow
 WHERE ID = @ID";


            List<DbParameter> parameters = new List<DbParameter>
                                           {
                                               DataBase.CreateInDbParameter("@ID",DbType.Int32, id),
                                               DataBase.CreateInDbParameter("@Name", name),
                                               DataBase.CreateInDbParameter("@Description",description),
                                               DataBase.CreateInDbParameter("@SortIndex",DbType.Int32, sortIndex),
                                               DataBase.CreateInDbParameter("@IsShow",DbType.Boolean, isShow),
                                           };

            DataBase.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        public static string GetTitleImage(int id)
        {
            string sql = "Select Top 1 * from [Photo] where [AlbumID]=@AlbumID order by SetAsTitleImage desc,SortIndex asc";

            List<DbParameter> parameters = new List<DbParameter>
                                           {
                                               DataBase.CreateInDbParameter("@AlbumID",DbType.Int32, id),
                                           };

            DataTable dt = DataBase.ExecuteDataSet(sql, CommandType.Text, parameters).Tables[0];

            if (dt.Rows.Count > 0)
                return dt.Rows[0]["TUrl"].ToString();

            return "";
        }

        public static DataSet SelectAllShowPhoto(int id)
        {
            string sql = "Select * from [Photo] where [AlbumID]=@AlbumID and isshow =1  order by SetAsTitleImage desc,SortIndex asc";

            List<DbParameter> parameters = new List<DbParameter>
                                           {
                                               DataBase.CreateInDbParameter("@AlbumID",DbType.Int32, id),
                                           };

            return DataBase.ExecuteDataSet(sql, CommandType.Text, parameters);
        }
    }
}
