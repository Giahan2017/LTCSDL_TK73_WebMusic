﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Common.Req
{
    public class SearchPlaylistReq
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string Id { get; set; }
        public string Keyword { get; set; }
    }
}
