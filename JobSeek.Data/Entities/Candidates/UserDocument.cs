using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSeek.Data
{
    [Table("UserDocuments")]
    public class UserDocument
    {
        [Key]
        public int DocumentID { get; set; }

        public int UserID { get; set; }
        public UserAccount Candidate { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; } 
        public string ContentType { get; set; }

        public DocumentType DocumentType { get; set; }

        public DateTime UploadedAt { get; set; }

        public bool IsDefault { get; set; }
    }

    public enum DocumentType
    {
        Resume,
        CoverLetter,
        Other
    }
}
