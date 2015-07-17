<%@ Page Title="" Language="C#" MasterPageFile="~/MPF.Master" AutoEventWireup="true" CodeBehind="AtenMedicos.aspx.cs" Inherits="FisiksAppWeb.AtenMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var txtFiltro = '#' + '<%=texto.ClientID %>';
            var grillaJedis = '#' + '<%=GridView1.ClientID %>';
            $(txtFiltro).quicksearch(grillaJedis + ' tbody tr');
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#contactForm').bootstrapValidator({
                container: '#messages',
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    fullName: {
                        validators: {
                            notEmpty: {
                                message: 'The full name is required and cannot be empty'
                            }
                        }
                    },
                    email: {
                        validators: {
                            notEmpty: {
                                message: 'The email address is required and cannot be empty'
                            },
                            emailAddress: {
                                message: 'The email address is not valid'
                            }
                        }
                    },
                    title: {
                        validators: {
                            notEmpty: {
                                message: 'The title is required and cannot be empty'
                            },
                            stringLength: {
                                max: 100,
                                message: 'The title must be less than 100 characters long'
                            }
                        }
                    },
                    content: {
                        validators: {
                            notEmpty: {
                                message: 'The content is required and cannot be empty'
                            },
                            stringLength: {
                                max: 500,
                                message: 'The content must be less than 500 characters long'
                            }
                        }
                    }
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="text" id="texto" name="texto" runat="server" />
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped"></asp:GridView>

    <div id="contactForm" class="form-horizontal">
        <div class="form-group">
            <label class="col-md-3 control-label">Full name</label>
            <div class="col-md-6">
                <input type="text" class="form-control" name="fullName" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-3 control-label">Email</label>
            <div class="col-md-6">
                <input type="text" class="form-control" name="email" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-3 control-label">Title</label>
            <div class="col-md-6">
                <input type="text" class="form-control" name="title" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-3 control-label">Content</label>
            <div class="col-md-6">
                <textarea class="form-control" name="content" rows="5"></textarea>
            </div>
        </div>
        <!-- #messages is where the messages are placed inside -->
        <div class="form-group">
            <div class="col-md-9 col-md-offset-3">
                <div id="messages"></div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-9 col-md-offset-3">
                <button type="submit" class="btn btn-default">Validate</button>
            </div>
        </div>
    </div>
</asp:Content>
