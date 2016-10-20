<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP229_F2016_MidTerm_300799984.TodoDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Todo Details</h1>
                <div class="form-group">
                    <label class="control-label" for="TodoDescriptionTextbox">Todo Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TodoDescriptionTextbox" 
                        placeholder="Todo Name" required="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label" for="TodoNotesTextBox">Todo Notes</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TodoNotesTextBox" 
                        placeholder="Todo Notes" required="false"></asp:TextBox>
                </div>

                    <asp:CheckBox ID="CompletedCheckBox"  runat="server" />
                    <label class="control-label" for="CompletedCheckBox">Completed</label>

                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server"
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server"
                        OnClick="SaveButton_Click" />
                </div>

            </div>
        </div>
  </div>
</asp:Content>
