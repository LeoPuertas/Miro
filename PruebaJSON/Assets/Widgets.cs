using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Miro.Apis
{
    [Serializable]
    public class Widgets
    {
        public string type ;
        public List<Datum> data ;
        public int size ;
    }

    [System.Serializable]
    public class Style
    {
        public object padding ;
        public double backgroundOpacity ;
        public string backgroundColor ;
        public string borderColor ;
        public string borderStyle ;
        public double borderOpacity ;
        public double borderWidth ;
        public int fontSize ;
        public string fontFamily ;
        public string textColor ;
        public string textAlign ;
        public object textAlignVertical ;
        public string shapeType ;
        public string lineEndType ;
        public string lineStartType ;
        public string lineType ;
    }

    [System.Serializable]
    public class CreatedBy
    {
        public string type ;
        public string name ;
        public string id ;
    }

    [System.Serializable]
    public class Mindmap
    {
        public string theme ;
        public string layout ;
        public bool? mindmap ;
    }

    [System.Serializable]
    public class StartWidget
    {
        public string id ;
    }

    [System.Serializable]
    public class EndWidget
    {
        public string id ;
    }

    [System.Serializable]
    public class Datum
    {
        public string id ;
        public Style style ;
        public string text ;
        public float x ;
        public float y ;
        public float width ;
        public float scale ;
        public float rotation ;
        public string type ;
        public DateTime createdAt ;
        public DateTime modifiedAt ;
        public ModifiedBy modifiedBy ;
        public CreatedBy createdBy ;
        public Mindmap mindmap ;
        public StartWidget startWidget ;
        public EndWidget endWidget ;
    }
}