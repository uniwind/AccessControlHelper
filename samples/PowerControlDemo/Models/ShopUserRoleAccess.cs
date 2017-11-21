﻿using WeihanLi.EntityFramework.DbDescriptionHelper;
using System;

namespace PowerControlDemo.Models
{
    [TableDescription("ShopUserRoleAccess", "用户角色访问权限")]
    public class ShopUserRoleAccessModel : BaseModel
    {
        private int roleId;

        [ColumnDescription("角色id")]
        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        private long accessId;

        [ColumnDescription("权限控制id")]
        public long AccessId
        {
            get { return accessId; }
            set { accessId = value; }
        }
    }
}