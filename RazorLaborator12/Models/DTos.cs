﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorLaborator12.Models
{
    [DataContract(IsReference = true)]
 public class CommentDTO
 {
     [DataMember]
     public int CommentId { get; set; }
     [DataMember]
     public string CommentText { get; set; }
     [DataMember]
     public int PostId { get; set; }
     [DataMember]
     public int PostPostId { get; set; }
     [DataMember]
     public virtual PostDTO Post { get; set; }
 }
 [DataContract]
 public class PostDTO
 {
     public PostDTO()
     {
     this.Comments = new List<CommentDTO>(); //new HashSet<Comment>();
     }
     [DataMember]
     public int PostId { get; set; }
     [DataMember]
     public string Title { get; set; }
     [DataMember]
     public virtual List<CommentDTO> Comments { get; set; }
 }

}
