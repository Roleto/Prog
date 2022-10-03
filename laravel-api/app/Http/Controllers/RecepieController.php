<?php

namespace App\Http\Controllers;

use App\Models\Recepie;
use App\Http\Requests\StoreRecepieRequest;
use App\Http\Requests\UpdateRecepieRequest;

class RecepieController extends Controller
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
     * @param  \App\Http\Requests\StoreRecepieRequest  $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreRecepieRequest $request)
    {
        //
    }

    /**
     * Display the specified resource.
     *
     * @param  \App\Models\Recepie  $recepie
     * @return \Illuminate\Http\Response
     */
    public function show(Recepie $recepie)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  \App\Models\Recepie  $recepie
     * @return \Illuminate\Http\Response
     */
    public function edit(Recepie $recepie)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \App\Http\Requests\UpdateRecepieRequest  $request
     * @param  \App\Models\Recepie  $recepie
     * @return \Illuminate\Http\Response
     */
    public function update(UpdateRecepieRequest $request, Recepie $recepie)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  \App\Models\Recepie  $recepie
     * @return \Illuminate\Http\Response
     */
    public function destroy(Recepie $recepie)
    {
        //
    }
}
