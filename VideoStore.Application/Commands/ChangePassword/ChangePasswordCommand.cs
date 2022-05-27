using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.ViewModels;

namespace VideoStore.Application.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Unit>
    {
        public int Id { get;  set; }
        public string OldPassword { get;  set; }
        public string NewPassword { get;  set; }

        public ChangePasswordCommand(int id, string oldPassword, string newPassword)
        {
            Id = id;
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }



    }
}
