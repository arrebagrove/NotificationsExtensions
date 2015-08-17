// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Runtime.CompilerServices;
using System.Text;
#if !WINRT_NOT_PRESENT
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
#endif

namespace NotificationsExtensions.Tiles
{

    /// <summary>
    /// Base tile element, which contains a single visual element.
    /// </summary>
    public sealed class TileContent
    {
        /// <summary>
        /// The visual element is required.
        /// </summary>
        public TileVisual Visual { get; set; }


        /// <summary>
        /// Retrieves the notification XML content as a string.
        /// </summary>
        /// <returns>The notification XML content as a string.</returns>
        public string GetContent()
        {
            return ConvertToElement().GetContent();
        }

#if !WINRT_NOT_PRESENT
        /// <summary>
        /// Retrieves the notification XML content as a WinRT XML document.
        /// </summary>
        /// <returns>The notification XML content as a WinRT XML document.</returns>
        public XmlDocument GetXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(GetContent());

            return doc;
        }

#endif

        internal Element_Tile ConvertToElement()
        {
            var tile = new Element_Tile();

            if (Visual != null)
                tile.Visual = Visual.ConvertToElement();

            return tile;
        }
    }
}