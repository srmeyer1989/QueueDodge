﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QueueDodge.Models;
using System.Data.Entity;

namespace QueueDodge.Services
{
    public class LeaderboardService
    {
        private QueueDodgeDB data { get; set; }

        public LeaderboardService()
        {
            data = new QueueDodgeDB();
        }

        public IEnumerable<LadderChange> GetRecentActivity(string bracket, BattleDotNet.Region region)
        {
            int lastComparison = data
                .LeaderboardComparisons
                .Where(p => p.CurrentRequest.Bracket == bracket && p.CurrentRequest.RegionID == (int)region)
                .OrderByDescending(p => p.ID)
                .Select(p => p.CurrentRequestID)
                .FirstOrDefault();

            IEnumerable<LadderChange> recentChanges = data
                .LadderChanges
                .Where(p => p.CurrentRequestID == lastComparison)
                 .Include(p => p.Realm)
                 .OrderBy(p => p.DetectedRanking)
                .AsEnumerable();

            return recentChanges;
        }

        public LeaderboardViewModel GetLeaderboard(LeaderboardFilter filter)
        {
            int requestID = GetRequestID(filter);

            int recordCount = GetCount(filter, requestID);

            int pageCount = recordCount / filter.ItemsPerPage;

            BattleDotNet.Region region = (BattleDotNet.Region)filter.Region;

            var filteredLeaderboard =
                data
                    .Leaderboards
                    //.Include(p => p.Request)
                    //.Include(p => p.Class.Specializations)
                    //.Include(p => p.Race.Faction)
                    //.Include(p => p.Spec)
                    //.Include(p => p.Realm.Region)
                    .Where(p => p.RequestID == requestID)
                    .Where(p => region == BattleDotNet.Region.all || p.RegionID == filter.Region)
                    .Where(p => filter.Classes.Count == 0 || filter.Classes.Contains(p.ClassID))
                    .Where(p => filter.Specs.Count == 0 || filter.Specs.Contains(p.SpecID))
                    .Where(p => filter.Realm == 0 || p.RealmID == filter.Realm);

            var pagedLeaderboard = GetPagedLeaderboard(filter, filteredLeaderboard);

            var vm = new LeaderboardViewModel()
            {
                Leaderboard = pagedLeaderboard,
                PageCount = pageCount,
                ItemsPerPage = filter.ItemsPerPage,
                TotalItemCount = recordCount,
                ClassRepresentation = GetClassRepresentation(filter, filteredLeaderboard),
                SpecializationRepresentation = GetSpecializationRepresentation(filter, filteredLeaderboard),
                RaceRepresentation = GetRaceRepresentation(filter, filteredLeaderboard),
                FactionRepresentation = GetFactionRepresentation(filter, filteredLeaderboard),
                RealmRepresentation = GetRealmRepresentation(filter, filteredLeaderboard),
                RegionRepresentation = GetRegionRepresentation(filter, filteredLeaderboard)
            };

            return vm;
        }

        public IEnumerable<Representation<int>> GetClassRepresentation(LeaderboardFilter filter, IQueryable<Leaderboard> leaderboard)
        {
            int requestID = GetRequestID(filter);

            int totalCount = GetCount(filter, requestID);

            var representation = leaderboard
                                    .GroupBy(p => p.ClassID)
                                    .Select(group => new Representation<int>
                                    {
                                        Data = group.Key,
                                        Count = group.Count(),
                                        Total = totalCount
                                    })
                                    .OrderByDescending(p => p.Count)
                                    .AsEnumerable();


            return representation;
        }
        public IEnumerable<Representation<object>> GetSpecializationRepresentation(LeaderboardFilter filter, IQueryable<Leaderboard> leaderboard)
        {
            int requestID = GetRequestID(filter);

            int totalCount = GetCount(filter, requestID);

            var representation = leaderboard
                                    .GroupBy(p => new { classID = p.ClassID, specID = p.SpecID } )
                                    .Select(group => new Representation<object>
                                    {
                                        Data = group.Key,
                                        Count = group.Count(),
                                        Total = totalCount
                                    })
                                    .OrderByDescending(p => p.Count)
                                    .Take(15)
                                    .ToList();

            return representation;
        }
        public IEnumerable<Representation<int>> GetRaceRepresentation(LeaderboardFilter filter, IQueryable<Leaderboard> leaderboard)
        {
            int requestID = GetRequestID(filter);

            int totalCount = GetCount(filter, requestID);

            var representation = leaderboard
                                    .GroupBy(p => p.RaceID)
                                    .Select(group => new Representation<int>
                                    {
                                        Data = group.Key,
                                        Count = group.Count(),
                                        Total = totalCount
                                    })
                                    .OrderByDescending(p => p.Count)
                                    .ToList();

            return representation;
        }
        public IEnumerable<Representation<object>> GetRealmRepresentation(LeaderboardFilter filter, IQueryable<Leaderboard> leaderboard)
        {
            int requestID = GetRequestID(filter);

            int totalCount = GetCount(filter, requestID);

            var representation = leaderboard
                                    .GroupBy(p => new { region = p.RegionID, realm = p.RealmName })
                                    .Select(group => new Representation<object>
                                    {
                                        Data = group.Key,
                                        Count = group.Count(),
                                        Total = totalCount
                                    })
                                    .OrderByDescending(p => p.Count)
                                    .OrderByDescending(p => p.Count)
                                    .Take(15)
                                    .ToList();

            return representation;
        }
        public IEnumerable<Representation<int>> GetFactionRepresentation(LeaderboardFilter filter, IQueryable<Leaderboard> leaderboard)
        {
            int requestID = GetRequestID(filter);

            int totalCount = GetCount(filter, requestID);

            var representation = leaderboard
                                    .GroupBy(p => p.FactionID)
                                    .Select(group => new Representation<int>
                                    {
                                        Data = group.Key,
                                        Count = group.Count(),
                                        Total = totalCount
                                    })
                                    .OrderByDescending(p => p.Count)
                                    .ToList();

            return representation;
        }
        public IEnumerable<Representation<int>> GetRegionRepresentation(LeaderboardFilter filter, IQueryable<Leaderboard> leaderboard)
        {
            int requestID = GetRequestID(filter);

            int totalCount = GetCount(filter, requestID);

            var representation = leaderboard
                                    .GroupBy(p => p.RegionID)
                                    .Select(group => new Representation<int>
                                    {
                                        Data = group.Key,
                                        Count = group.Count(),
                                        Total = totalCount
                                    })
                                    .OrderBy(p => p.Count)
                                    .ToList();

            return representation;
        }

        private int GetRequestID(LeaderboardFilter filter)
        {
            return data
                .Leaderboards
                .Where(p => p.Bracket == filter.Bracket && p.RegionID == filter.Region)
                .OrderByDescending(p => p.RequestID)
                .Select(p => p.RequestID)
                .FirstOrDefault();
        }

        private int GetCount(LeaderboardFilter filter, int requestID)
        {
            filter.Classes = filter.Classes ?? new List<int>();
            filter.Specs = filter.Specs ?? new List<int>();

            return data.Leaderboards
                       .Where(p => p.RequestID == requestID)
                       .Where(p => filter.Classes.Count == 0 || filter.Classes.Contains(p.ClassID))
                       .Where(p => filter.Specs.Count == 0 || filter.Specs.Contains(p.SpecID))
                       .Where(p => filter.Realm == 0 || p.RealmID == filter.Realm)
                       .Count();
        }

        private IEnumerable<Leaderboard> GetPagedLeaderboard(LeaderboardFilter filter, IQueryable<Leaderboard> leaderboard)
        {
            filter.Page--;
            if (filter.Page != 0)
            {
                leaderboard =
                    leaderboard
                        .OrderBy(p => p.Ranking)
                        .Skip(filter.Page * filter.ItemsPerPage)
                        .Take(filter.ItemsPerPage)
                        .Select(p => p);
            }
            else
            {
                leaderboard =
                    leaderboard
                        .OrderBy(p => p.Ranking)
                        .Take(filter.ItemsPerPage)
                        .Select(p => p);
            }

            return leaderboard.AsEnumerable();
        }
    }
}
