using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public class DBAdapter
{

    string conStr;
    SqlConnection conn;

    public int QuestionQuantity { get; set; }

    public DBAdapter()
    {
        conStr = ConfigurationManager.ConnectionStrings["CrossFileConn"].ToString();
        conn = new SqlConnection(conStr);

        QuestionQuantity = GetQuestions().Rows.Count;
    }

    public void InsertUser(int? ID, string email, string password, string firstname, string surname, string organization, string salutation, bool isActive, bool refProfile, DateTime datecreated, DateTime dateupdated, DateTime datedeleted, DateTime? emailed, int groupID, int roleID)
    {

        SqlCommand cmd = new SqlCommand("InsertUser", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Password", password);
        cmd.Parameters.AddWithValue("@Firstname", firstname);
        cmd.Parameters.AddWithValue("@Surname", surname);
        cmd.Parameters.AddWithValue("@Organisation", organization);
        cmd.Parameters.AddWithValue("@Salutation", salutation);
        cmd.Parameters.AddWithValue("@IsActive", isActive);
        cmd.Parameters.AddWithValue("@ReferenceProfile", refProfile);
        cmd.Parameters.AddWithValue("@DateCreated", datecreated);
        cmd.Parameters.AddWithValue("@DateUpdated", dateupdated);
        cmd.Parameters.AddWithValue("@DateDeleted", datedeleted);
        cmd.Parameters.AddWithValue("@Emailed", emailed);
        cmd.Parameters.AddWithValue("@GroupID", groupID);
        cmd.Parameters.AddWithValue("@RoleID", roleID);
        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            // return true;
        }
        catch (Exception ex)
        {
            throw ex;
            // conn.Close();
            //return false;
        }

    }

    public DataTable GetUsers(int? id)
    {
        SqlCommand cmd = new SqlCommand("GetUsers", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Id", id);

        SqlDataAdapter dtAdapter = new SqlDataAdapter(cmd);

        DataTable dtTableUsers = new DataTable();

        if (conn.State != ConnectionState.Open)
            conn.Open();

        dtAdapter.Fill(dtTableUsers);

        conn.Close();

        return dtTableUsers;


    }

    public DataTable GetUserInfo(int? Groupid)
    {
        SqlCommand cmd = new SqlCommand("GetUserInfo", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@GroupID", Groupid);

        SqlDataAdapter dtAdapter = new SqlDataAdapter(cmd);

        DataTable dtTableUserInfo = new DataTable();

        if (conn.State != ConnectionState.Open)
            conn.Open();

        dtAdapter.Fill(dtTableUserInfo);

        conn.Close();

        return dtTableUserInfo;


    }

    public DataTable UserGroups()
    {

        SqlCommand cmd = new SqlCommand("GetUserGroups", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public bool ChangePassowrd(int? ID, string email, string password, string salutation)
    {
        SqlCommand cmd = new SqlCommand("ChangePassword", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", ID);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@salutation", salutation);
        cmd.Parameters.AddWithValue("@password", password);
        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {
            conn.Close();
            return false;
        }
    }

    public DataTable CheckUser(string email, string password)
    {
        SqlCommand cmd = new SqlCommand("CheckUser", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@password", password);

        SqlDataAdapter dtAdapter = new SqlDataAdapter(cmd);

        DataTable dtTableUsers = new DataTable();

        if (conn.State != ConnectionState.Open)
            conn.Open();

        dtAdapter.Fill(dtTableUsers);

        conn.Close();

        return dtTableUsers;
    }

    public int QuestionMaxId(int? userID)
    {

        SqlCommand cmd = new SqlCommand("GetQuestionMaxID", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@userID", userID);
        int questionID = 0;
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            questionID = (Int32)cmd.ExecuteScalar();
            conn.Close();
        }
        catch (Exception)
        {
            conn.Close();
        }
        return questionID;
    }

    public DataTable QuestionContent(int? questionID)
    {

        SqlCommand cmd = new SqlCommand("GetQuestionContent", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@QuestionID", questionID);


        SqlDataAdapter dtAdapter = new SqlDataAdapter(cmd);

        DataTable Question = new DataTable();

        if (conn.State != ConnectionState.Open)
            conn.Open();

        dtAdapter.Fill(Question);

        conn.Close();

        return Question;
    }

    public DataTable AnswerContent(int? questionID)
    {
        SqlCommand cmd = new SqlCommand("GetAnswerContent", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@QuestionID", questionID);

        DataTable Answers = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(Answers);

        conn.Close();
        return Answers;

    }

    public bool InsertQuestionnaire(int userID, int questionID, int answerID, DateTime? dateCreated, DateTime? dateUpdated)
    {
        SqlCommand cmd = new SqlCommand("InsertQuestionnaire", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@questionID", questionID);
        cmd.Parameters.AddWithValue("@answerID", answerID);
        cmd.Parameters.AddWithValue("@dateCreated", dateCreated);
        cmd.Parameters.AddWithValue("@dateUpdated", dateUpdated);
        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }

    }

    public DataTable GetQuestionList(int? userID)
    {
        SqlCommand cmd = new SqlCommand("GetQuestionList", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@userID", userID);

        DataTable QuestionList = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(QuestionList);

        conn.Close();
        return QuestionList;

    }

    public DataTable GetQuestionGroups()
    {
        SqlCommand cmd = new SqlCommand("GetQuestionGroup", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        DataTable QuestionGroups = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(QuestionGroups);

        conn.Close();
        return QuestionGroups;


    }

    public bool DeleteQuestionGroup(int id)
    {
        SqlCommand cmd = new SqlCommand("DeleteQuestionGroup", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }
    }

    public DataTable GetAnswerCategories(int? temp)
    {
        SqlCommand cmd = new SqlCommand("GetAnswerCategories", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TempVariable", temp);


        DataTable AnswerCategories = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(AnswerCategories);

        conn.Close();
        return AnswerCategories;


    }

    public bool DeleteAnswerCategory(int id)
    {
        SqlCommand cmd = new SqlCommand("DeleteAnswerCategory", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }
    }

    public bool InsertAnswerCategory(string name)
    {

        SqlCommand cmd = new SqlCommand("InsertAnswerCategory", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@Name", name);

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }

    }

    public DataTable GetAnswers(int? categoryID)
    {
        SqlCommand cmd = new SqlCommand("GetAnswers", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CategoryID", categoryID);


        DataTable Answers = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(Answers);

        conn.Close();
        return Answers;


    }

    public DataTable GetAnswerCategoryName(int? categoryID)
    {
        SqlCommand cmd = new SqlCommand("GetAnswerCategoryName", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CategoryID", categoryID);


        DataTable Categoryname = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(Categoryname);

        conn.Close();
        return Categoryname;


    }

    public bool DeleteAnswer(int id)
    {
        SqlCommand cmd = new SqlCommand("DeleteAnswer", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }
    }

    public bool InsertAnswer(int? ID, string content, double score, int categoryID, string color, int order)
    {
        SqlCommand cmd = new SqlCommand("InsertAnswer", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@id", ID);
        cmd.Parameters.AddWithValue("@Content", content);
        cmd.Parameters.AddWithValue("@Score", score);
        cmd.Parameters.AddWithValue("@categoryID", categoryID);
        cmd.Parameters.AddWithValue("@color", color);
        cmd.Parameters.AddWithValue("@order", order);

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }

    }

    public DataTable GetAnswersByID(int? AnswerID)
    {
        SqlCommand cmd = new SqlCommand("GetAnswersByID", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@AnswerID", AnswerID);


        DataTable Answers = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(Answers);

        conn.Close();
        return Answers;


    }

    public DataTable GetQuestionGroupInfo(int? GroupID)
    {
        SqlCommand cmd = new SqlCommand("GetQuestionGroupInfo", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@GroupID", GroupID);


        DataTable QuestionGroupInfo = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(QuestionGroupInfo);

        conn.Close();
        return QuestionGroupInfo;


    }

    public bool InsertQuestionGroupInfo(int? GroupID, string Name, string Description, string AttributeA, string AttributeB, int Order, double MaxAnswerScore, string Color)
    {
        SqlCommand cmd = new SqlCommand("InsertQuestionGroupInfo", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@GroupId", GroupID);
        cmd.Parameters.AddWithValue("@Name", Name);
        cmd.Parameters.AddWithValue("@Description", Description);
        cmd.Parameters.AddWithValue("@AttributeA", AttributeA);
        cmd.Parameters.AddWithValue("@AttributeB", AttributeB);
        cmd.Parameters.AddWithValue("@Order", Order);
        cmd.Parameters.AddWithValue("@MaxAnswerScore", MaxAnswerScore);
        cmd.Parameters.AddWithValue("@Color", Color);
       

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }

    }

    public DataTable GetQuestionInfo(int? GroupId)
    {

        SqlCommand cmd = new SqlCommand("GetQuestionInfo", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@GroupId", GroupId);


        DataTable Questions = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(Questions);

        conn.Close();
        return Questions;


    }

    public int CheckLastQuestion(int userID)
    {
        Int32 result = 0;
        SqlCommand cmd = new SqlCommand("CheckLastQuestion", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@userID", userID);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        result = (Int32)cmd.ExecuteScalar();

        conn.Close();

        return result;
    }

    public DataTable getQuestionGroupAttributes(int userid)
    {

        SqlCommand cmd = new SqlCommand("GetQuestionGroupInfoForProfile", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@userID", userid);



        DataTable Attributes = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(Attributes);

        conn.Close();
        return Attributes;


    }

    public void InsertQuestion(int? id, double? wght, int? groupid, int order, string content, int? categoryID)
    {
        SqlCommand cmd = new SqlCommand("InsertQuestion", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@id", id);

        cmd.Parameters.AddWithValue("@Wght", wght);
        cmd.Parameters.AddWithValue("@GroupID", groupid);

        cmd.Parameters.AddWithValue("@QuestionOrder", order);
        cmd.Parameters.AddWithValue("@Content", content);
        cmd.Parameters.AddWithValue("@categoryid", categoryID);



        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            // return true;
        }
        catch (Exception ex)
        {
            throw ex;
            //conn.Close();
            //return false;
        }


    }

    public void UpdateQuestion(int? id, string Content, int? categoryid, int? order)
    {
        SqlCommand cmd = new SqlCommand("UpdateQuestion", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@Content", Content);
        cmd.Parameters.AddWithValue("@AnsCatID", categoryid);
        cmd.Parameters.AddWithValue("@order", order);
        



        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            // return true;
        }
        catch (Exception ex)
        {
            throw ex;
            //conn.Close();
            //return false;
        }


    }

    public bool DeleteQuestion(int id)
    {
        SqlCommand cmd = new SqlCommand("DeleteQuestion", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }
    }

    public DataTable GetQuestions()
    {
        SqlCommand cmd = new SqlCommand("GetQuestions", conn);
        cmd.CommandType = CommandType.StoredProcedure;




        DataTable Questions = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(Questions);

        conn.Close();
        return Questions;




    }

    public bool DeleteUserGroup(int id)
    {
        SqlCommand cmd = new SqlCommand("DeleteUserGroup", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", id);

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }
    }

    public void InsertUserGroup(int? id, string Name, DateTime date)
    {
        SqlCommand cmd = new SqlCommand("InsertUserGroup", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@Description", Name);
        cmd.Parameters.AddWithValue("@Date", date);



        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            //  return true;
        }
        catch (Exception ex)
        {
            throw ex;
            //conn.Close();
            //return false;
        }


    }

    public DataTable GetUserGroup(int id)
    {

        SqlCommand cmd = new SqlCommand("GetUserGroup", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", id);



        DataTable UserGroup = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(UserGroup);

        conn.Close();
        return UserGroup;


    }

    public DataTable GetQuestion(int? Qid)
    {

        SqlCommand cmd = new SqlCommand("GetQuestion", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Qid", Qid);



        DataTable question = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(question);

        conn.Close();
        return question;


    }

    public DataRow GetUserByEmail(string email)
    {
        using (SqlConnection conn = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("GetUserByEmail", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@email", email));

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt.Rows.Count == 0 ? null : dt.Rows[0];
        }



    }

    public DataTable GetProfileDifferences(int? id)
    {
        SqlCommand cmd = new SqlCommand("GetProfileDifferences", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);



        DataTable ProfileDifferences = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(ProfileDifferences);

        conn.Close();
        return ProfileDifferences;


    }

    public int CheckUserOnRegistration(string email)
    {

        SqlCommand cmd = new SqlCommand("CheckUserOnRegistration", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@email", email);
        int userCount = 0;
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            userCount = (Int32)cmd.ExecuteScalar();
            conn.Close();
        }
        catch (Exception)
        {
            conn.Close();
        }
        return userCount;
    }

    public bool DeleteProfileDifferences(int id)
    {
        SqlCommand cmd = new SqlCommand("DeleteProfileDifferences", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }
    }

    public void InsertProfileDefference(int? id, int? from, int? to, string level, byte[] icon)
    {
        SqlCommand cmd = new SqlCommand("InsertProfileDefference", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@from", from);
        cmd.Parameters.AddWithValue("@to", to);
        cmd.Parameters.AddWithValue("@level", level);
        cmd.Parameters.AddWithValue("@icon", icon);



        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            //  return true;
        }
        catch (Exception ex)
        {
            throw ex;
            //conn.Close();
            //return false;
        }


    }

    public DataTable GetProfileDifference(int? id)
    {

        SqlCommand cmd = new SqlCommand("GetProfileDifference", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);



        DataTable ProfileDifference = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(ProfileDifference);

        conn.Close();
        return ProfileDifference;


    }

    public DataTable GetAllUserByGroupId(int? id)
    {

        SqlCommand cmd = new SqlCommand("GetAllUserByGroupId", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@groupID", id);



        DataTable users = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(users);

        conn.Close();
        return users;


    }

    public DataTable GetUserByGroupId(int? id)
    {

        SqlCommand cmd = new SqlCommand("GetUserByGroupId", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@groupID", id);



        DataTable users = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(users);

        conn.Close();
        return users;


    }

    public void UpdateUserEmailedDate(int? ID, DateTime Emailed)
    {
        SqlCommand cmd = new SqlCommand("UpdateUserEmailedDate", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@Emailed", Emailed);




        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            //  return true;
        }
        catch (Exception ex)
        {
            throw ex;
            //conn.Close();
            //return false;
        }


    }

    public void EnableUser(int? ID, bool isActive)
    {
        SqlCommand cmd = new SqlCommand("EnableUser", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@id", ID);
        cmd.Parameters.AddWithValue("@IsActive", isActive);




        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            //  return true;
        }
        catch (Exception ex)
        {
            throw ex;
            //conn.Close();
            //return false;
        }


    }

    public DataTable GetCountries()
    {

        SqlCommand cmd = new SqlCommand("GetCountries", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        DataTable countries = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(countries);

        conn.Close();
        return countries;


    }

    public bool DeleteCountry(int id)
    {
        SqlCommand cmd = new SqlCommand("DeleteCountry", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }
    }

    public DataTable GetScoreDifferences(int? id)
    {

        SqlCommand cmd = new SqlCommand("GetScoreDifferences", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);

        DataTable ScoreDifferences = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(ScoreDifferences);

        conn.Close();
        return ScoreDifferences;


    }

    public bool DeleteScoreDifferences(int id)
    {
        SqlCommand cmd = new SqlCommand("DeleteScoreDifferences", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }
    }

    public void InsertScoreDefference(int? ID, int? from, int? to, string level, string style, string primary, string secondary)
    {
        SqlCommand cmd = new SqlCommand("InsertScoreDefference", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@id", ID);
        cmd.Parameters.AddWithValue("@from", from);
        cmd.Parameters.AddWithValue("@to", to);
        cmd.Parameters.AddWithValue("@level", level);
        cmd.Parameters.AddWithValue("@Style", style);
        cmd.Parameters.AddWithValue("@PrimaryPrefix", primary);
        cmd.Parameters.AddWithValue("@SecondaryPrefix", secondary);
        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            //  return true;
        }
        catch (Exception ex)
        {
            throw ex;
            //conn.Close();
            //return false;
        }


    }

    public void InsertUserInfoForEmail(int userID, int questionID, string guid)
    {
        SqlCommand cmd = new SqlCommand("InsertUserInfoForEmail", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@UserID", userID);
        cmd.Parameters.AddWithValue("@QuestionID", questionID);
        cmd.Parameters.AddWithValue("@Guid", guid);

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            //  return true;
        }
        catch (Exception ex)
        {
            throw ex;
            //conn.Close();
            //return false;
        }


    }


    public int CheckEmailLink(int userID, int questionID, string guid)
    {

        SqlCommand cmd = new SqlCommand("CheckEmailLink", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserID", userID);
        cmd.Parameters.AddWithValue("@Guid", guid);
        cmd.Parameters.AddWithValue("@QuestionID", questionID);

        int result = 0;
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            result = (Int32)cmd.ExecuteScalar();
            conn.Close();
        }
        catch (Exception)
        {
            conn.Close();
        }
        return result;
    }

    public bool DeleteUserInfoForEmail(int userID, int questionID, string guid)
    {
        SqlCommand cmd = new SqlCommand("DeleteUserInfoForEmail", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserID", userID);
        cmd.Parameters.AddWithValue("@Guid", guid);
        cmd.Parameters.AddWithValue("@QuestionID", questionID);

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception)
        {

            conn.Close();
            return false;
        }
    }

    public DataTable GetComparison(int userid, int countryid)
    {
        SqlCommand cmd = new SqlCommand("GetComparison", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserID", userid);
        cmd.Parameters.AddWithValue("@CountryID", countryid);


        DataTable comparison = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(comparison);

        conn.Close();
        return comparison;


    }

    public int GetIconByScore(double ProfileDifference)
    {

        SqlCommand cmd = new SqlCommand("GetIconByScore", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ProfileDifference", ProfileDifference);


        int result = -1;
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            result = (Int32)cmd.ExecuteScalar();
            conn.Close();
        }
        catch (Exception)
        {
            conn.Close();
        }
        return result;
    }

    public DataTable GetScoreDifferenceByScore(double? Score)
    {
        SqlCommand cmd = new SqlCommand("GetScoreDifferenceByScore", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ScoreDifference", Score);



        DataTable DifferenceByScore = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(DifferenceByScore);

        conn.Close();
        return DifferenceByScore;


    }

    public int GetQuestionGroupByID(int id)
    {

        SqlCommand cmd = new SqlCommand("GetQuestionGroupByID", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", id);


        int result = 0;
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            result = (Int32)cmd.ExecuteScalar();
            conn.Close();
        }
        catch (Exception)
        {
            conn.Close();
        }
        return result;
    }

    public void UpdateEmptyQuestion(int? id, double? wght, int? groupid, int order, int? categoryID)
    {
        SqlCommand cmd = new SqlCommand("UpdateEmptyQuestion", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@Wght", wght);
        cmd.Parameters.AddWithValue("@GroupID", groupid);
        cmd.Parameters.AddWithValue("@QuestionOrder", order);
        cmd.Parameters.AddWithValue("@categoryid", categoryID);



        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            // return true;
        }
        catch (Exception ex)
        {
            throw ex;
            //conn.Close();
            //return false;
        }



    }
    public DataTable GetQuestionForGroup(int? ID)
    {
        SqlCommand cmd = new SqlCommand("GetQuestionForGroup", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@qID", ID);



        DataTable QUESTIONiNFO = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        if (conn.State != ConnectionState.Open)
            conn.Open();

        adapter.Fill(QUESTIONiNFO);

        conn.Close();
        return QUESTIONiNFO;


    }
}