@extends('layout')
@section('title', 'CreatingWarehouse')
@section('content')
<div class="">
    <form class="" method="POST" action="{{route('warehouse.store')}}">
    @csrf
        <div class="mb-3">
            <label class="form-label"  for="name">Name</label><p>
            <input class="" type="text" name="name" id="name">
        </div>
        <div>
            <label class="" for="materialtype">Materialtype</label><p>
            <input class="" type="text" name="materialtype" id="materialtype">
        </div>
        <div>
            <label class="" for="price">Price</label><p>
            <input class="" type="text" name="price" id="price">
        </div>
        <div>
            <label class="" for="quantity">Quantity</label><p>
            <input class="" type="text" name="quantity" id="quantity">
        </div>
        <div>
            <button class=""  type="submit">Submit</button>
        </div>
    </form>

</div>
@endsection