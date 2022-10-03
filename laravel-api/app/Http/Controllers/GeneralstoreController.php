<?php

namespace App\Http\Controllers;

use App\Models\Generalstore;
use App\Http\Requests\StoreGeneralstoreRequest;
use App\Http\Requests\UpdateGeneralstoreRequest;

class GeneralstoreController extends Controller
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
     * @param  \App\Http\Requests\StoreGeneralstoreRequest  $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreGeneralstoreRequest $request)
    {
        //
    }

    /**
     * Display the specified resource.
     *
     * @param  \App\Models\Generalstore  $generalstore
     * @return \Illuminate\Http\Response
     */
    public function show(Generalstore $generalstore)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  \App\Models\Generalstore  $generalstore
     * @return \Illuminate\Http\Response
     */
    public function edit(Generalstore $generalstore)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \App\Http\Requests\UpdateGeneralstoreRequest  $request
     * @param  \App\Models\Generalstore  $generalstore
     * @return \Illuminate\Http\Response
     */
    public function update(UpdateGeneralstoreRequest $request, Generalstore $generalstore)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  \App\Models\Generalstore  $generalstore
     * @return \Illuminate\Http\Response
     */
    public function destroy(Generalstore $generalstore)
    {
        //
    }
}
