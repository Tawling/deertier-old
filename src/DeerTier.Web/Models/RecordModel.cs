﻿using System;

namespace DeerTier.Web.Models
{
    public class RecordModel
    {
        public int Id { get; set; }
        public string Player { get; set; }
        public int RealTimeSeconds { get; set; }
        public string RealTimeString { get; set; }
        public int GameTimeSeconds { get; set; }
        public string GameTimeString { get; set; }
        public string Comment { get; set; }
        public string VideoURL { get; set; }
        public float CeresTime { get; set; }
        public string FormattedRealTime { get; set; }
        public string FormattedGameTime { get; set; }
        public string FormattedEscapeGameTime { get; set; }
        public string HtmlComment { get; set; }
        public DateTime? DateSubmitted { get; set; }

        public int Rank { get; set; }
        public string VideoURLAsLink
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.VideoURL))
                {
                    return "";
                }
                return "<a href=\"" + VideoURL + "\" target=\"_blank\">Watch</a>";
            }
        }

        public string DateSubmittedAsString
        {
            get
            {
                if (DateSubmitted.HasValue)
                {
                    return string.Format("Submitted by {0} on: {1}", Player, DateSubmitted.Value.ToString("dd/MM/yyyy"));
                }
                return "Submission date unavailable";
            }
        }
    }
}