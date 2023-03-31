##citz-imb-full-stack-code-challenge-req97073

Thank you for taing the time to review my solution.
This submission talks only to the backend API, with Swagger documentation and pushed to Docker hub.

Backend API Framework: APS.NETCORE 6
To run the solution.
Github: 
1. Clone the repository.
2. DB is a simple Json file, hence no need to install any ORM
3. Swagger UI middleware included https://localhost:3000/swagger/index

Docker:
1. Clone the built image from Docker hub: "docker pull toemot2006/bcprovinceapp:latest".
2. build the image
3. run the image: 
	"docker run -p 3000:80 -e ASPNETCORE_ENVIRONMENT="Development" -d toemot2006/bcprovinceapp"
	goto: http://localhost:3000/swagger/index.html


API solution contains
1. A health endpoint that returns a http 200 response indicating your component is healthy using xUnit testing framework
2. All GET, POST, PUT and DELETE endpoints that return the proper response codes when consumed.
Sample JSON Schema
    {
        productId: VALUE,
        productName: VALUE,
        productOwnerName: VALUE,
        Developers: [
         "NAME_1",
         "NAME_2",
         "NAME_3",
         "NAME_4",
         "NAME_5"
        ],
        scrumMasterName: VALUE,
        startDate: "YYYY/MM/DD",
        methodology: VALUE
    }


SWAGGER Documentation.
http://localhost:3000/swagger/v1/swagger.json
@model IEnumerable<WeighBridge.Data.PrePaidCouponBookList>

@{
    ViewBag.Title = "Coupon Books";
}

<p>
    <h4 class="text-center">
        Prepaid Coupon Books
    </h4>
</p>
<div class="row">
    <div class="col-md-12 text-right">
        <button id="btnAddPrepaidBulkCouponBooks" type="button" class="btn btn-primary" Style="width: 280px; margin-bottom:1%;"
                onclick="location.href='@Url.Action("CreateBPC")'">
            Add Bulk Coupon Books
        </button>
        <button id="btnAddPrepaidCoupon" type="button" class="btn btn-primary" Style="width: 200px; margin-bottom:1%;"
                onclick="location.href='@Url.Action("Create")'">
            Add Coupon Book
        </button>
@*        <button type="submit" style="margin-right: 10px;" class="btn btn-primary float-right" onclick="location.href='@Url.Action("SyncCoupon")'" id="btnSyncCoupon">Sync Coupons</button>*@

    </div>
</div>

<table class="display nowrap table table-striped" id="tblBooks">
    <thead class="table-header">
        <tr>
            <th>
                @Html.Label("Book Id")
            </th>
            <th>
                @Html.Label("Book Number")
            </th>
            <th>
                @Html.Label("Number Of Coupons")

            </th>
            <th>
                @Html.Label("Book Value")
            </th>
            <th>
                @Html.Label("Location")
            </th>
            <th>
                @Html.Label("Status")
            </th>
            <th>
                @Html.Label("FinancialYear")
            </th>
            <th>
                @Html.Label("Coupon Type")
            </th>
            <th></th>
        </tr>
    </thead>
</table>

<style>
    #btnAdd,
    #btnUpdate {{
  "openapi": "3.0.1",
  "info": {
    "title": "BCProviceApp",
    "version": "1.0"
  },
  "paths": {
    "/api/Product": {
      "get": {
        "tags": [
          "Product"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ProductDTO"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ProductDTO"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ProductDTO"
                  }
                }
              }
            }
          }
        }
      },
      "post": {
        "tags": [
          "Product"
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/Product"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Product"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Product"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Product"
              }
            }
          }
        },
        "responses": {
          "201": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ProductDTO"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProductDTO"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProductDTO"
                }
              }
            }
          },
          "404": {
            "description": "Not Found",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          }
        }
      }
    },
    "/api/Product/{name}": {
      "get": {
        "tags": [
          "Product"
        ],
        "parameters": [
          {
            "name": "searchQuery",
            "in": "query",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "name",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ProductDTO"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ProductDTO"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ProductDTO"
                  }
                }
              }
            }
          }
        }
      }
    },
    "/api/Product/{productId}": {
      "get": {
        "tags": [
          "Product"
        ],
        "operationId": "GetProduct",
        "parameters": [
          {
            "name": "productId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ProductDTO"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProductDTO"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProductDTO"
                }
              }
            }
          },
          "404": {
            "description": "Not Found",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          }
        }
      },
      "put": {
        "tags": [
          "Product"
        ],
        "parameters": [
          {
            "name": "productId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/Product"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Product"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Product"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Product"
              }
            }
          }
        },
        "responses": {
          "204": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Product"
        ],
        "parameters": [
          {
            "name": "productId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "400": {
            "description": "Bad Request",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          },
          "204": {
            "description": "Success"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "Methodology": {
        "enum": [
          1,
          2
        ],
        "type": "integer",
        "format": "int32"
      },
      "ProblemDetails": {
        "type": "object",
        "properties": {
          "type": {
            "type": "string",
            "nullable": true
          },
          "title": {
            "type": "string",
            "nullable": true
          },
          "status": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "detail": {
            "type": "string",
            "nullable": true
          },
          "instance": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": { }
      },
      "Product": {
        "required": [
          "developerName",
          "methodology",
          "productName",
          "productOwner",
          "scrumMaster",
          "startDate"
        ],
        "type": "object",
        "properties": {
          "productId": {
            "type": "integer",
            "format": "int32"
          },
          "productName": {
            "type": "string"
          },
          "scrumMaster": {
            "type": "string"
          },
          "productOwner": {
            "type": "string"
          },
          "developerName": {
            "type": "array",
            "items": {
              "type": "string"
            }
          },
          "startDate": {
            "type": "string",
            "format": "date-time"
          },
          "methodology": {
            "$ref": "#/components/schemas/Methodology"
          }
        },
        "additionalProperties": false
      },
      "ProductDTO": {
        "required": [
          "developerName",
          "methodology",
          "productName",
          "productOwner",
          "scrumMaster",
          "startDate"
        ],
        "type": "object",
        "properties": {
          "productId": {
            "type": "integer",
            "format": "int32"
          },
          "productName": {
            "type": "string"
          },
          "scrumMaster": {
            "type": "string"
          },
          "productOwner": {
            "type": "string"
          },
          "developerName": {
            "type": "array",
            "items": {
              "type": "string"
            }
          },
          "startDate": {
            "type": "string",
            "format": "date-time"
          },
          "methodology": {
            "$ref": "#/components/schemas/Methodology"
          }
        },
        "additionalProperties": false
      }
    }
  }
}
        display: inline-block;
        vertical-align: top;
    }
</style>

<link href="~/Content/DataTables/css/jquery.dataTables.css" rel="stylesheet" />
<script language="javascript">

    $(document).ready(function () {
        GenerateTable();
    });

    function GenerateTable() {
        $('#tblBooks').DataTable({
            dom:
                "<'row'<'col-sm-3'l><'col-sm-3'f><'col-sm-6'p>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-5'i><'col-sm-7'p>>",
            "sPaginationType": "full_numbers",
            "bFilter": false,
            "searching": true,
            "bLengthChange": true,
            "bServerSide": true,
            "bProcessing": true,
            "bAutoWidth": false,
            "iDisplayLength": 5,
            "bSort": true,
            "ajax": {
                "url": "@Url.Action("GetPrepaidCouponBooks")",
                "type": "POST",
                'contentType': 'application/json; charset=utf-8',
                'data': function (data) {
                    var tempData = {};
                    tempData.pageRequest = data;
                    return JSON.stringify(tempData);
                },
            },
            "aaSorting": [[0, "asc"]],
            "aoColumns": [
                {
                    "sName": "PrepaidCouponBookId",
                    "width": "7%"
                },
                {
                    "sName": "BookNumber",
                    "width":"7%"
                },
                {
                    "sName": "NumberofCoupons",
                    "width": "10%"
                },
                {
                    "sName": "BookValue",
                    "width": "10%"
                },
                {
                    "sName": "Location",
                    "width": "7%"
                },
                {
                    "sName": "Status",
                    "width": "7%"
                },
                {
                    "sName": "Year",
                    "width": "7%"
                },
                {
                    "sName": "CouponType",
                    "width": "10%"
                },
                {
                    render: function (data, type, row) {
                        return '<p><a class="btn btn-sm btn-primary" href="@Url.Action("Edit")' + "/" + row[0] + '"><i class="bi-pencil"></i></a> | <a class="btn btn-sm btn-primary" href="@Url.Action("Details")' + "/" + row[0] + '"><i class="bi-binoculars"></i></a> @*| <a class="btn btn-sm btn-primary" href="@Url.Action("ViewValidate")' + "/" + row[0] + '"><i class="bi-hand-thumbs-up"></i></a>*@ | <a class="btn btn-sm btn-primary" href="@Url.Action("ViewIssue")' + "/" + row[0] + '"><i class="bi-check"></i></a> | <a class="btn btn-sm btn-primary" href="@Url.Action("Delete")' + "/" + row[0] + '"><i class="bi-trash"></i></a> </p>'
                    },
                    "width": "10%"
                }]
        });
    }

</script>
