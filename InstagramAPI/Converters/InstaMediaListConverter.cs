﻿using System;
using System.Linq;
using InstagramAPI.Classes.Models;
using InstagramAPI.ResponseWrappers;

namespace InstagramAPI.Converters
{
    internal class InstaMediaListConverter : IObjectConverter<InstaMediaList, InstaMediaListResponse>
    {
        public InstaMediaListResponse SourceObject { get; set; }

        public InstaMediaList Convert()
        {
            if (SourceObject == null) throw new ArgumentNullException($"Source object");
            var mediaList = new InstaMediaList();
            mediaList.AddRange(SourceObject.Items.Select(ConvertersFabric.GetSingleMediaConverter).Select(converter => converter.Convert()));
            return mediaList;
        }
    }
}