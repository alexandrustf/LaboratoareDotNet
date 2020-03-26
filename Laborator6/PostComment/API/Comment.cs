using System.Linq;
using System.Data.Entity;
namespace PostComment
{
    public partial class Comment
    {
        public bool AddComment()
        {
            using (Model2Container ctx = new Model2Container())
            {
                bool bResult = false;
                if (this == null || this.PostPostId == 0)
                    return bResult;
                if (this.Id == 0)
                {
                    ctx.Entry<Comment>(this).State = EntityState.Added;
                    Post p = ctx.Posts.Find(this.PostPostId);
                    ctx.Entry<Post>(p).State = EntityState.Unchanged;
                    ctx.SaveChanges();
                    bResult = true;
                }
                return bResult;
            }
        }
        public Comment UpdateComment(Comment newComment)
        {
            using (Model2Container ctx = new Model2Container())
            {
                Comment oldComment = ctx.Comments.Find(newComment.Id);
                // Deoarece parametrul este un Comment ar trebui verificata fiecare
                // proprietate din newComment daca are valoare atribuita si
                // daca valoarea este diferita de cea din bd.
                // Acest lucru il fac numai la modificarea asocierii.
                if (newComment.Text != null)
                    oldComment.Text = newComment.Text;
                if ((oldComment.PostPostId != newComment.PostPostId)
                    && (newComment.PostPostId != 0))
                {
                    oldComment.PostPostId = newComment.PostPostId;
                }
                ctx.SaveChanges();
                return oldComment;
            }
        }
        public Comment GetCommentById(int id)
        {
            using (Model2Container ctx = new Model2Container())
            {
                var items = from c in ctx.Comments where (c.Id == id) select c;
                return items.Include(p => p.Post).SingleOrDefault();
            }
        }
    }
}