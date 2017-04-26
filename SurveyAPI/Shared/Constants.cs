using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyAPI.Shared
{
    public class Constants
    {
        #region Msg_notification
        //insert
        public const string MSG_INSERT_SUCCESS = "Thêm mới {0} thành công";
        public const string MSG_INSERT_FAIL = "Thêm mới{0} thất bại";
        //update
        public const string MSG_UPDATE_SUCCESS = "Cập nhật {0} thành công";
        public const string MSG_UPDATE_FAIL = "Cập nhật {0} thất bại";
        //delete
        public const string MSG_DELETE_SUCCESS = "Xóa {0} thành công";
        public const string MSG_DELETE_FAIL = "Xóa {0} thất bại";
        //input data
        public const string MSG_INPUT_WRONG = "Dữ liệu đầu vào không hợp lệ";
        public const string MSG_DUPLICATE_ID = "Đã tồn tại bản ghi";

        //select success
        public const string MSG_SELECT_SUCCESS = "Lấy dữ liệu {0} thành công ";
        //
        public const string MSG_SELECT_FAIL = "Lấy dữ liệu {0} thất bại ";
        //
        #endregion
        #region Error Msg Content
        public const string MESSAGE_NOT_EXIST_DATA = "Không tồn tại dữ liệu phù hợp hoặc trong CSDL chưa có dữ liệu tương ứng";
        public const string MESSAGE_NOT_EXIST_DATA_USER_GROUP = "Chưa tồn tại nhóm người dùng trong hệ thống!";
        public const string MESSAGE_WRONG_USER_OR_PASSWORD = "Sai tên đăng nhập hoặc mật khẩu";
        public const string MESSAGE_CANNOT_CREATE_ADMIN_RECORD = "Không thể tạo tài khoản có tên đăng nhập là admin";
        public const string MESSAGE_ERROR_EXCEL_CONTENT = "Có một số các bản ghi chưa hợp lệ! vui sửa lại file";
        #endregion

        #region Table name
        public const string SurveyType = "Loại bảng hỏi";
        public const string SurveyInfo = "Bảng hỏi";
        public const string Question = "Câu hỏi";
        public const string QuestionType = "Loại câu hỏi";
        public const string QuestionGroup = "Nhóm câu hỏi";
        public const string Choices = "Lựa chọn";
        public const string Answer  = "Câu trả lời";
        public const string AnswerPaper = "Bảng trả lời";
        public const string AccountnGroup = "Nhóm người dùng";
        public const string Account = "Người dùng";
        public const string Role  = "Quyền";
        public const string RoleDetail = "Chi tiết quyền";

        #endregion
        public enum SearchType
        {
            Name =1,
            CreatedDate =2,
            Id =3,

        }
    }
}