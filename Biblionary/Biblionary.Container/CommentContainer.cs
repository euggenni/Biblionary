using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblionary.BLL;
using Biblionary.BLL.Interface;
using Biblionary.DAL;
using Biblionary.DAL.Interface;

namespace Biblionary.Container
{
    class CommentContainer
    {
        public static IBiblionaryCommentDao CommentDao = new BiblionaryCommentDao();

        public static ICommentLogic CommentLogic = new CommentLogic(CommentDao);
    }
}
