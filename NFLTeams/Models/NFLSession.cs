﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace NFLTeams.Models
{
    public class NFLSession
    {
        private const string TeamsKey = "myteams";
        private const string CountKey = "teamcount";
        private const string ConfKey = "conf";
        private const string DivKey = "div";
        private const string Username = "username";
        //var UserName = User.Identity.Name;

        private ISession session { get; set; }
        //set username method created by me
       
        //public void GetUserName(UserName)
        //{
        //    session.GetString(user,UserName)
        //}
        //public void SetUserName()
        //{

        //}
        public NFLSession(ISession session) {
            this.session = session;
        }

        public void SetMyTeams(List<Team> teams) {
            session.SetObject(TeamsKey, teams);
            session.SetInt32(CountKey, teams.Count);
        }
        public List<Team> GetMyTeams() =>
            session.GetObject<List<Team>>(TeamsKey) ?? new List<Team>();
        public int? GetMyTeamCount() => session.GetInt32(CountKey);

        public void SetActiveConf(string conference) =>
            session.SetString(ConfKey, conference);
        public string GetActiveConf() => session.GetString(ConfKey);

        public void SetUserName(string username) =>
           session.SetString(Username, username);
        public string GetUserName() => session.GetString(Username);

        public void SetActiveDiv(string division) =>
            session.SetString(DivKey, division);
        public string GetActiveDiv() => session.GetString(DivKey);

        public void RemoveMyTeams() {
            session.Remove(TeamsKey);
            session.Remove(CountKey);
        }
    }
}
