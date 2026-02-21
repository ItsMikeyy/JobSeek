using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSeek.Data
{
    [Table("CandidateDocuments")]
    public class CandidateDocument
    {
        [Key]
        public int DocumentID { get; set; }

        public int CandidateID { get; set; }
        public Candidate Candidate { get; set; }

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
