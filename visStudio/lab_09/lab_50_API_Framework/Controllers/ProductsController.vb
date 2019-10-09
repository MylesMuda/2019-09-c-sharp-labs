Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports lab_50_API_Framework.lab_50_API_Framework

Namespace Controllers
    Public Class ProductsController
        Inherits System.Web.Http.ApiController

        Private db As New NorthwindEntities

        ' GET: api/Products
        Function GetProducts() As IQueryable(Of Product)
            Return db.Products
        End Function

        ' GET: api/Products/5
        <ResponseType(GetType(Product))>
        Function GetProduct(ByVal id As Integer) As IHttpActionResult
            Dim product As Product = db.Products.Find(id)
            If IsNothing(product) Then
                Return NotFound()
            End If

            Return Ok(product)
        End Function

        ' PUT: api/Products/5
        <ResponseType(GetType(Void))>
        Function PutProduct(ByVal id As Integer, ByVal product As Product) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = product.ProductID Then
                Return BadRequest()
            End If

            db.Entry(product).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (ProductExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Products
        <ResponseType(GetType(Product))>
        Function PostProduct(ByVal product As Product) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Products.Add(product)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = product.ProductID}, product)
        End Function

        ' DELETE: api/Products/5
        <ResponseType(GetType(Product))>
        Function DeleteProduct(ByVal id As Integer) As IHttpActionResult
            Dim product As Product = db.Products.Find(id)
            If IsNothing(product) Then
                Return NotFound()
            End If

            db.Products.Remove(product)
            db.SaveChanges()

            Return Ok(product)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function ProductExists(ByVal id As Integer) As Boolean
            Return db.Products.Count(Function(e) e.ProductID = id) > 0
        End Function
    End Class
End Namespace