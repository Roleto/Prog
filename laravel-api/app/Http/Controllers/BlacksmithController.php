<?php

namespace App\Http\Controllers;

use App\Models\Blacksmith;
use App\Http\Requests\StoreBlacksmithRequest;
use App\Http\Requests\UpdateBlacksmithRequest;

class BlacksmithController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        //
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        //
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \App\Http\Requests\StoreBlacksmithRequest  $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreBlacksmithRequest $request)
    {
        //
    }

    /**
     * Display the specified resource.
     *
     * @param  \App\Models\Blacksmith  $blacksmith
     * @return \Illuminate\Http\Response
     */
    public function show(Blacksmith $blacksmith)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  \App\Models\Blacksmith  $blacksmith
     * @return \Illuminate\Http\Response
     */
    public function edit(Blacksmith $blacksmith)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \App\Http\Requests\UpdateBlacksmithRequest  $request
     * @param  \App\Models\Blacksmith  $blacksmith
     * @return \Illuminate\Http\Response
     */
    public function update(UpdateBlacksmithRequest $request, Blacksmith $blacksmith)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  \App\Models\Blacksmith  $blacksmith
     * @return \Illuminate\Http\Response
     */
    public function destroy(Blacksmith $blacksmith)
    {
        //
    }
}
