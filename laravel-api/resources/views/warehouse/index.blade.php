@extends('layout')
@section('title', 'Warehouse')
@section('content')
<div class= "max-w-6xl mx-auto sm:px-6 lg:px-8"> 
    <table>
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
            <td>{{$ware['materialtype']}}</td>
            <td>{{$ware['quantity']}}</td>
            <td>{{$ware['price']}}</td>
            <!-- <td><a href="{{ route('destroy', $production['id']) }}">X</a></td> -->
        </tr>
            @endforeach
        @endif
    </table>
</div>
@endsection