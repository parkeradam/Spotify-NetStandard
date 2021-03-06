﻿using System.ComponentModel;

namespace Spotify.NetStandard.Requests
{
    /// <summary>
    /// Authorisation Scopes 
    /// </summary>
    public class Scope
    {
        #region Playlists
        /// <summary>
        /// Read access to user's private playlists.
        /// <para>Required For</para>
        /// <para>Check if Users Follow a Playlist,
        /// Get a List of Current User's Playlists,
        /// Get a List of a User's Playlists</para>
        /// </summary>
        [Description("playlist-read-private")]
        public bool? PlaylistReadPrivate { get; set; }

        /// <summary>
        /// Write access to a user's private playlists. 
        /// <para>Required For</para>
        /// <para>Follow a Playlist,
        /// Unfollow a Playlist,
        /// Add Tracks to a Playlist</para>
        /// <para>Change a Playlist's Details,
        /// Create a Playlist,
        /// Remove Tracks from a Playlist</para>
        /// <para>Reorder a Playlist's Tracks,
        /// Replace a Playlist's Tracks,
        /// Upload a Custom Playlist Cover Image</para>
        /// </summary>
        [Description("playlist-modify-private")]
        public bool? PlaylistModifyPrivate { get; set; }

        /// <summary>
        /// Write access to a user's public playlists. 
        /// <para>Required For</para>
        /// <para>Follow a Playlist,
        /// Unfollow a Playlist,
        /// Add Tracks to a Playlist</para>
        /// <para>Change a Playlist's Details,
        /// Create a Playlist,
        /// Remove Tracks from a Playlist</para>
        /// <para>Reorder a Playlist's Tracks,
        /// Replace a Playlist's Tracks,
        /// Upload a Custom Playlist Cover Image</para>
        /// </summary>
        [Description("playlist-modify-public")]
        public bool? PlaylistModifyPublic { get; set; }

        /// <summary>
        /// Include collaborative playlists when requesting a user's playlists. 
        /// <para>Required For</para>
        /// <para>Get a List of Current User's Playlists,
        /// Get a List of a User's Playlists</para>
        /// </summary>
        [Description("playlist-read-collaborative")]
        public bool? PlaylistReadCollaborative { get; set; }
        #endregion Playlists

        #region Spotify Connect 
        /// <summary>
        /// Pause a User's Playback
        /// <para>Required For</para>
        /// <para>Seek To Position In Currently Playing Track,
        /// Set Repeat Mode On User’s Playback,
        /// Set Volume For User's Playback</para>
        /// <para>Skip User’s Playback To Next Track,
        /// Skip User’s Playback To Previous Track,
        /// Start/Resume a User's Playback</para>
        /// <para>Toggle Shuffle For User’s Playback
        /// Transfer a User's Playback</para>
        /// </summary>
        [Description("user-modify-playback-state")]
        public bool? ConnectModifyPlaybackState { get; set; }

        /// <summary>
        /// Read access to a user’s currently playing track
        /// <para>Required For</para>
        /// <para>Get the User's Currently Playing Track</para>
        /// </summary>
        [Description("user-read-currently-playing")]
        public bool? ConnectReadCurrentlyPlaying { get; set; }

        /// <summary>
        /// Read access to a user’s player state.
        /// <para>Required For</para>
        /// <para>Get a User's Available Devices,
        /// Get Information About The User's Current Playback,
        /// Get the User's Currently Playing Track</para>
        /// </summary>
        [Description("user-read-playback-state")]
        public bool? ConnectReadPlaybackState { get; set; }
        #endregion Spotify Connect 

        #region Listening History
        /// <summary>
        /// Read access to a user's top artists and tracks. 
        /// <para>Required For</para>
        /// <para>Get a User's Top Artists and Tracks</para>
        /// </summary>
        [Description("user-top-read")]
        public bool? ListeningTopRead { get; set; }

        /// <summary>
        /// Read access to a user’s recently played tracks
        /// <para>Required For</para>
        /// <para>Get Current User's Recently Played Tracks</para>
        /// </summary>
        [Description("user-read-recently-played")]
        public bool? ListeningRecentlyPlayed { get; set; }
        #endregion Listening History

        #region Playback
        /// <summary>
        /// Remote control playback of Spotify.
        /// </summary>
        [Description("app-remote-control")]
        public bool? PlaybackAppRemoteControl { get; set; }

        /// <summary>
        /// Control playback of a Spotify track. The user must have a Spotify Premium account. 
        /// </summary>
        [Description("streaming")]
        public bool? PlaybackStreaming { get; set; }
        #endregion Playback

        #region Users
        /// <summary>
        /// Read access to the user's birthdate.
        /// <para>Required For</para>
        /// <para>Get Current User's Profile</para>
        /// </summary>
        [Description("user-read-birthdate")]
        public bool? UserReadBirthDate { get; set; }

        /// <summary>
        /// Read access to user’s email address. 
        /// <para>Required For</para>
        /// <para>Get Current User's Profile</para>
        /// </summary>
        [Description("user-read-email")]
        public bool? UserReadEmail { get; set; }

        /// <summary>
        /// Read access to user’s subscription details (type of user account). 
        /// <para>Required For</para>
        /// <para>Search for an Item,
        /// Get Current User's Profile</para>
        /// </summary>
        [Description("user-read-private")]
        public bool? UserReadPrivate { get; set; }

        /// <summary>
        /// User Generated Content Image Upload
        /// <para>Required For</para>
        /// <para>Upload a Custom Playlist Cover Image</para>
        /// </summary>
        [Description("ugc-image-upload")]
        public bool? UserGeneratedContentImageUpload { get; set; }
        #endregion Users

        #region Follow
        /// <summary>
        /// Read access to the list of artists and other users that the user follows.
        /// <para>Required For</para>
        /// <para>Check if Current User Follows Artists or Users,
        /// Get User's Followed Artists</para>
        /// </summary>
        [Description("user-follow-read")]
        public bool? FollowRead { get; set; }

        /// <summary>
        /// Write/delete access to the list of artists and other users that the user follows.
        /// <para>Required For</para>
        /// <para>Follow Artists or Users,
        /// Unfollow Artists or Users</para>
        /// </summary>
        [Description("user-follow-modify")]
        public bool? FollowModify { get; set; }
        #endregion Follow

        #region Library
        /// <summary>
        /// Write/delete access to a user's "Your Music" library. 
        /// <para>Required For</para>
        /// <para>Remove Albums for Current User,
        /// Remove User's Saved Tracks,
        /// Save Albums for Current User
        /// Save Tracks for User</para>
        /// </summary>
        [Description("user-library-modify")]
        public bool? LibraryModify { get; set; }

        /// <summary>
        /// Read access to a user's "Your Music" library.  
        /// <para>Required For</para>
        /// <para>Check User's Saved Albums
        /// Check User's Saved Tracks,
        /// Get Current User's Saved Albums
        /// Get a User's Saved Tracks</para>
        /// </summary>
        [Description("user-library-read")]
        public bool? LibraryRead { get; set; }
        #endregion Library
    }
}
