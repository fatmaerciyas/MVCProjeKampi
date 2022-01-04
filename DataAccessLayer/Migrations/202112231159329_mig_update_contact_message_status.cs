namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_contact_message_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactMessageStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "MessageStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "MessageStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "ContactMessageStatus");
        }
    }
}
