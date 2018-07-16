using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblionary.Entities;
using Biblionary.BLL.Interface;
using Biblionary.DAL.Interface;

namespace Biblionary.BLL
{
    public class CommentLogic: ICommentLogic
    {
        private readonly IBiblionaryCommentDao _commentDao;

        #region MyRegion

        public CommentLogic(IBiblionaryCommentDao commentDao)
        {
            _commentDao = commentDao;
        }

        #endregion

        #region Methods

        public int AddComment(Comment comment)
        {
            try
            {
                return _commentDao.AddComment(comment);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return 0;
            }
        }

        public IEnumerable<Comment> ReadComments(int id)
        {
            try
            {
                return _commentDao.ReadComments(id);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return null;
            }
        }

        #endregion
    }
}
