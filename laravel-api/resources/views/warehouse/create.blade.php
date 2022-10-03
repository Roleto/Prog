@extends('layout')
@section('title', 'CreatingWarehouse')
@section('content')
<div class="max-w-6xl bg-white dark:bg-gray-800  text-gray-500 mx-auto sm:px-6 lg:px-8 ">
    <form class="form  p-6  border-1" method="POST" action="">
    @csrf
        <div>
            <label class="text-sm"  for="name">Name</label><p>
            <input class="text-lg border-1" type="text" name="name" id="name">
        </div>
        <div>
            <label class="text-sm" for="materialtype">Materialtype</label><p>
            <input class="text-lg" type="text" name="materialtype" id="materialtype">
        </div>
        <div>
            <label class="text-sm" for="price">Price</label><p>
            <input class="text-lg " type="text" name="price" id="price">
        </div>
        <div>
            <label class="text-sm" for="quantity">Quantity</label><p>
            <input class="text-lg" type="text" name="quantity" id="quantity">
        </div>
        <div>
            <button class="border-1"  type="submit">Submit</button>
        </div>
    </form>

</div>
@endsection