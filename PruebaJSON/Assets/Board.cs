using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Miro.Apis
{
    [System.Serializable]
    public class Board
    {
        public string type;
        public object currentUserConnection;
        public string viewLink;
        public string name;
        public string id;
        public Owner owner;
        public string description;
        public DateTime createdAt;
        public SharingPolicy sharingPolicy;
        public DateTime modifiedAt;
        public ModifiedBy modifiedBy;
        public Picture picture;
        public CreatedBy createdBy;
        public Team team;
    }
    [System.Serializable]
    public class Owner
    {
        public string type;
        public string name;
        public string id;
    }
    [System.Serializable]
    public class SharingPolicy
    {
        public string access;
        public string teamAccess;
        public string accountAccess;
    }
    [System.Serializable]
    public class ModifiedBy
    {
        public string type;
        public string name;
        public string id;
    }
    [System.Serializable]
    public class Picture
    {
        public string type;
        public string imageUrl;
        public string id;
    }

    [System.Serializable]
    public class Team
    {
        public string type;
        public string name;
        public string id;
    }
}
