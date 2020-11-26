<%@ Page Language="C#" CodeFile="Success.aspx.cs" Inherits="Success" %>
<!DOCTYPE html>
<html lang="ko">
<head>
    <title>결제 성공</title>
    <meta charset="UTF8"/>
    <meta http-equiv="x-ua-compatible" content="ie=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
</head>
<body>
<section>
    <% if(isSuccess) { %>
      <h1>결제 성공</h1>
        <h3>상품명: 토스 티셔츠</h3>
        <h3>결과 데이터: <%= successData %></h3>
    <% } else { %>
        <h1>결제 실패</h1>
        <p><%= message %></p>
        <span>에러코드: <%= code %></span>
    <% } %>

</section>
</body>
</html>
