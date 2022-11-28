@extends('layout')
@section('title', 'Warehouse')
@section('content')
<div class="col-md-4 "> 
    <table class="table  table-responsive table-dark table-borderless table-sm table-hover">
        <tr>    
            <td>Id</td>
            <td>Name</td>
            <td>Materialtype</td>
            <td>Quantity</td>
            <td>Price</td>
        </tr>
        @if (count($wares) > 0)
            @foreach($wares as $ware)
        <tr>
            <td>{{$ware['id']}}</td>
            <td>{{$ware['name']}}</td>
            <td>{{$ware['materialType']}}</td>
            <td>{{$ware['quantity']}}</td>
            <td>{{$ware['price']}}</td>
        </tr>
            @endforeach
        @endif
    </table>
</div>
@endsection