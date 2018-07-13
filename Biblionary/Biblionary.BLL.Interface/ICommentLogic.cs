using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblionary.Entities;

namespace Biblionary.BLL.Interface
{
    public interface ICommentLogic
    {
        void AddComment(Comment comment);

        IEnumerable<Comment> ReadComments(int id);
    }
}
